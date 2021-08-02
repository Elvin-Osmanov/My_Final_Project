using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Areas.Manage.ViewModels;
using Restabook.Data;
using Restabook.Data.Entities;

namespace Restabook.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
    [Area("Manage")]
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Menus.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            MenuViewModel menuVM = new MenuViewModel
            {
                Menus = await _context.Menus.Skip((page - 1) * 5).Take(5).ToListAsync()
            };
            return View(menuVM);
        }

        public async Task<IActionResult> Create()
        {
            Menu menu = await _context.Menus.FirstOrDefaultAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Menu menu)
        {
           

            if (!ModelState.IsValid)
                return View();

            if (await _context.Menus.AnyAsync(x => x.Name.ToLower() == menu.Name.Trim().ToLower()))
            {
                ModelState.AddModelError("Name", "Menu already exist!");
                return View();
            }

            if (await _context.Menus.AnyAsync(x => x.Order == menu.Order))
            {
                ModelState.AddModelError("Order", "Order already exist!");
                return View();
            }



            menu.Name = menu.Name.Trim();
            menu.CreatedDate = DateTime.UtcNow;
            menu.ModifiedDate = DateTime.UtcNow;

            

            

            await _context.Menus.AddAsync(menu);



            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Menu menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);

            if (menu == null)
            {
                return NotFound();
            }



            ViewBag.Id = id;

            return View(menu);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Menu menu)
        {
            Menu menuExist = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);

            if (menuExist == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return View();

            if (await _context.Menus.AnyAsync(x => x.Id != id && x.Name.ToLower() == menu.Name.Trim().ToLower()))
            {
                ModelState.AddModelError("Name", "Menu already exists!");
                return View();
            }


            menuExist.Name = menu.Name;
            menuExist.Order = menu.Order;
            menuExist.ModifiedDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Menu menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Menu menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);

            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Menu menuModel)
        {
            Menu menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == menuModel.Id);

            if (menu == null)
            {
                return NotFound();
            }

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
