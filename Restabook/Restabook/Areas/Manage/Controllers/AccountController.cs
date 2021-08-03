using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restabook.Areas.Manage.ViewModels;
using Restabook.Data;
using Restabook.Data.Entities;

namespace Restabook.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }


        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(UserRegisterViewModel userRegister)
        {
            if (!ModelState.IsValid)
                return View();

            AppUser member = await _userManager.FindByEmailAsync(userRegister.Email);

            if (member != null)
            {
                ModelState.AddModelError("", "Email already used");
                return View();
            }
            else
            {
                member = await _userManager.FindByNameAsync(userRegister.UserName);

                if (member != null)
                {
                    ModelState.AddModelError("", "Username already used");
                    return View();
                }
            }

            member = new AppUser
            {
                UserName = userRegister.UserName,
                Email = userRegister.Email,
                FullName = userRegister.FullName,
              
                PhoneNumber = userRegister.PhoneNumber,
              
            };

            var result = await _userManager.CreateAsync(member, userRegister.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(member, "Moderator");


            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,member.UserName),
                new Claim(ClaimTypes.Email, member.Email),
                new Claim(ClaimTypes.Role,"Moderator")
            }, "Moderator_Auth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync("Moderator_Auth", claimsPrincipal);

            return RedirectToAction("listusers", "administration");


           
        }

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

           
            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
              
                Roles = userRoles
            };


            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel editUser)
        {
            var user = await _userManager.FindByIdAsync(editUser.Id);

            if (user == null) { 
                return NotFound(); 
            }
            else
            {
                user.Email = editUser.Email;
                user.UserName = editUser.UserName;
                user.PhoneNumber = editUser.PhoneNumber;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("listusers", "administration");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(editUser);
            }

        }


        public async Task<IActionResult> DeleteUser(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);

             if (user == null)
            {
                return NotFound();
            }
            else
            {
              

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("listusers", "administration");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return RedirectToAction("listusers", "administration");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

       

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser admin = await _userManager.FindByNameAsync(loginVM.UserName);

            if (admin == null)
            {
                ModelState.AddModelError("", "Username or Password is incorrect!");
                return View();
            }

            if (!await _userManager.CheckPasswordAsync(admin, loginVM.Password))
            {
                ModelState.AddModelError("", "Username or Password is incorrect!");
                return View();
            }


            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,admin.UserName),
                new Claim(ClaimTypes.Role,"Admin")
            }, "Admin_Auth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await HttpContext.SignInAsync("Admin_Auth", claimsPrincipal);

            return RedirectToAction("index", "dashboard");
        }

        //public async Task Create()
        //{
        //    AppUser user = new AppUser
        //    {
        //        UserName = "SuperAdmin",
        //        FullName = "Supern Admin",
        //    };



        //    await _userManager.CreateAsync(user, "admin666");

        //    await _userManager.AddToRoleAsync(user, "Admin");

        //}

 


        public async Task<IActionResult> Profile()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
                return NotFound();

            return View(user);
        }

        [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(AppUser user)
        {
            AppUser existUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (existUser == null)
                return NotFound();


            if (_context.Users.Any(u => u.FullName == user.FullName && u.Id != existUser.Id))
            {
                ModelState.AddModelError("Fullname", "Fullname already used");
                return View();
            }


            existUser.FullName = user.FullName;

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

            return RedirectToAction("index", "dashboard");
        }
    }
}
