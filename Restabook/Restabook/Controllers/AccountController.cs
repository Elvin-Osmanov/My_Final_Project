using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Restabook.Data;
using Restabook.Data.Entities;
using Restabook.Data.Enums;
using Restabook.ViewModels;

namespace Restabook.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberLoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser member = await _userManager.FindByEmailAsync(loginVM.Email);

            if (member == null)
            {
                ModelState.AddModelError("", "Email or passowrd is incorrect!");
                return View();
            }

            if (!await _userManager.CheckPasswordAsync(member, loginVM.Password))
            {
                ModelState.AddModelError("", "Email or passowrd is incorrect!");
                return View();
            }

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier,member.Id),
                new Claim(ClaimTypes.Name,member.UserName),
                new Claim(ClaimTypes.Email, member.Email),
                new Claim(ClaimTypes.Role,"Member")
            }, "Member_Auth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var props = new AuthenticationProperties();
            props.IsPersistent = loginVM.RememberMe;
            await HttpContext.SignInAsync("Member_Auth", claimsPrincipal,props);

            return RedirectToAction("index", "home");

        }

        public IActionResult Register()
        {
            var GenderOptions = new List<SelectListItem>();


            foreach (var item in Enum.GetValues(typeof(Gender)))
            {
                GenderOptions.Add(new SelectListItem
                {
                    Value = item.ToString(),
                    Text = Enum.GetName(typeof(Gender), item)

                });
            }

            ViewBag.gender = GenderOptions;
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(MemberRegisterViewModel registerVM)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser member = await _userManager.FindByEmailAsync(registerVM.Email);

            if (member != null)
            {
                ModelState.AddModelError("", "Email already used");
                return View();
            }
            else
            {
                member = await _userManager.FindByNameAsync(registerVM.UserName);

                if (member != null)
                {
                    ModelState.AddModelError("", "Username already used");
                    return View();
                }
            }

            var GenderOptions = new List<SelectListItem>();


            foreach (var item in Enum.GetValues(typeof(Gender)))
            {
                GenderOptions.Add(new SelectListItem
                {
                    Value = item.ToString(),
                    Text = Enum.GetName(typeof(Gender), item)

                });
            }

            ViewBag.gender = GenderOptions;

            member = new AppUser
            {
                UserName = registerVM.UserName,
                Email = registerVM.Email,
                FullName = registerVM.FullName,
                Gender = registerVM.Gender,
                PhoneNumber=registerVM.PhoneNumber,
                Birthdate=registerVM.Birthdate
            };

            var result = await _userManager.CreateAsync(member, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(member, "Member");


            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,member.UserName),
                new Claim(ClaimTypes.Email, member.Email),
                new Claim(ClaimTypes.Role,"Member")
            }, "Member_Auth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            
            await HttpContext.SignInAsync("Member_Auth", claimsPrincipal);

            return RedirectToAction("index", "home");
        }


        [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
        public async Task<IActionResult> Profile()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            Reservation reservation = _context.Reservations.FirstOrDefault(x => x.AppUserId == user.Id);

            ViewBag.reservation=reservation;
            
            if (user == null)
                return NotFound();
            var GenderOptions = new List<SelectListItem>();


            foreach (var item in Enum.GetValues(typeof(Gender)))
            {
                GenderOptions.Add(new SelectListItem
                {
                    Value = item.ToString(),
                    Text = Enum.GetName(typeof(Gender), item)

                });
            }

            ViewBag.gender = GenderOptions;

            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
        public async Task<IActionResult> Profile(AppUser user)
        {
            AppUser existUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (existUser == null)
                return NotFound();


            if (_context.Users.Any(u => u.Email == user.Email && u.Id != existUser.Id))
            {
                ModelState.AddModelError("Email", "Email already used");
                return View();
            }
            var GenderOptions = new List<SelectListItem>();


            foreach (var item in Enum.GetValues(typeof(Gender)))
            {
                GenderOptions.Add(new SelectListItem
                {
                    Value = item.ToString(),
                    Text = Enum.GetName(typeof(Gender), item)

                });
            }

            ViewBag.gender = GenderOptions;

            existUser.Email = user.Email;
            existUser.FullName = user.FullName;
            existUser.Birthdate = user.Birthdate;
            existUser.Gender = user.Gender;
            existUser.PhoneNumber = user.PhoneNumber;
            

            if (!string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.CurrentPassword) && !string.IsNullOrWhiteSpace(user.ConfirmPassword))
            {
                var resultPass = await _userManager.ChangePasswordAsync(existUser, user.CurrentPassword, user.Password);
                if (!resultPass.Succeeded)
                {
                    ModelState.AddModelError("CurrentPassword", "Password incorrect!");
                    return View();
                }
            }

            await _userManager.UpdateAsync(existUser);

            return RedirectToAction("index", "home");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Member_Auth");

            return RedirectToAction("index", "home");
        }
    }
}
