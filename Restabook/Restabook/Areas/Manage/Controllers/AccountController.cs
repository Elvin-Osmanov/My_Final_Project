using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Login(AdminLoginViewModel loginVM)
        {
            return View();
        }

        public async Task Create()
        {
            AppUser user = new AppUser
            {
                UserName = "SuperAdmin",
                FullName = "Super Admin",
            };


            await _userManager.AddToRoleAsync(user, "Admin");

            await _userManager.CreateAsync(user, "admin");
            
        }

        //public async Task CreateRole()
        //{

        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
           

        //}
    }
}
