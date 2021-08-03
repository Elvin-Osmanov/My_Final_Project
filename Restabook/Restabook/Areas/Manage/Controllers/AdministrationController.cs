using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Areas.Manage.ViewModels;
using Restabook.Data.Entities;

namespace Restabook.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index(int page=1)
        {
          

            double totalCount = _roleManager.Roles.Count();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            IEnumerable<IdentityRole> roles = _roleManager.Roles.Skip((page - 1) * 5).Take(5);

            return View(roles);
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Moderator", AuthenticationSchemes = "Admin_Auth,Moderator_Auth")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRole)
        {
            var existRole = await _roleManager.RoleExistsAsync(createRole.RoleName);

            if (existRole)
            {
                ModelState.AddModelError("Role", "This role exists");
            }


            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = createRole.RoleName
                };

                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

                return RedirectToAction("index");
        }

        public async Task<IActionResult> EditRole(string id)
        {
            ViewBag.role = id;

            var existRole = await _roleManager.FindByIdAsync(id);

            if (existRole == null)
            {
                NotFound();
            }

            var editedRole = new EditRoleViewModel
            {
                RoleName = existRole.Name
            };

            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, existRole.Name))
                {
                    editedRole.Users.Add(user.UserName);
                }
            }

            return View(editedRole);
        }

        [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(EditRoleViewModel editRole)
        {
            var existRole = await _roleManager.FindByIdAsync(editRole.Id);

            if (existRole == null)
            {
                NotFound();
            }

            existRole.Name = editRole.RoleName;

            var result = await _roleManager.UpdateAsync(existRole);

            if (result.Succeeded)
            {
                return RedirectToAction("index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(existRole);
        }


        [HttpGet]
        public async Task<IActionResult> EditUserInRole(string id)
        {
            ViewBag.roleId = id;

            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                NotFound();
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in _userManager.Users)
            {
                var userModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userModel.IsSelected = true;
                }
                else
                {
                    userModel.IsSelected = false;
                }

                model.Add(userModel);

            }

            return View(model);
        }

        [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> EditUserInRole(List<UserRoleViewModel> listmodel, string id)
        {
            ViewBag.roleId = id;

            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                NotFound();
            }

            for (int i = 0; i < listmodel.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(listmodel[i].UserId);

                IdentityResult result = null;

                if (listmodel[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!listmodel[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (listmodel.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = id });
                }
            }

            return RedirectToAction("EditRole", new { Id = id });
        }


        public IActionResult ListUsers(int page=1)
        {
            double totalCount = _roleManager.Roles.Count();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            

            var users = _userManager.Users;

            return View(users);
        }

        
       
    }
}
