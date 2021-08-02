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



        //    await _userManager.CreateAsync(user, "admin123");

        //    await _userManager.AddToRoleAsync(user, "Admin");

        //}

        //public async Task CreateRole()
        //{

        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });




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
