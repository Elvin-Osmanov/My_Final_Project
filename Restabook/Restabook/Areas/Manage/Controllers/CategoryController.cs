using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Areas.Manage.ViewModels;
using Restabook.Data;
using Restabook.Data.Entities;

namespace Restabook.Areas.Manage.Controllers
{
    
        [Area("Manage")]
        public class CategoryController : Controller
        {
            private readonly AppDbContext _context;

            public CategoryController(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IActionResult> Index(int page = 1)
            {
                double totalCount = await _context.Categories.CountAsync();
                int pageCount = (int)Math.Ceiling(totalCount / 4);

                if (page < 1) page = 1;
                else if (page > pageCount) page = pageCount;

                ViewBag.PageCount = pageCount;
                ViewBag.SelectedPage = page;

                CategoryViewModel categoryVM = new CategoryViewModel
                {
                    Categories = await _context.Categories.Skip((page - 1) * 4).Take(4).ToListAsync()
                };
                return View(categoryVM);
            }

            public async Task<IActionResult> Create()
            {
                Category category = await _context.Categories.FirstOrDefaultAsync();

                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Category category)
            {
                if (!ModelState.IsValid)
                    return View();

                if (await _context.Categories.AnyAsync(x => x.Name.ToLower() == category.Name.Trim().ToLower()))
                {
                    ModelState.AddModelError("Name", "Category already exist!");
                    return View();
                }




                category.Name = category.Name.Trim();
                category.CreatedDate = DateTime.UtcNow;
                category.ModifiedDate = DateTime.UtcNow;
                
                await _context.Categories.AddAsync(category);

                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }

            public async Task<IActionResult> Edit(int id)
            {
                Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                {
                    return NotFound();
                }

                

                ViewBag.Id = id;

                return View(category);
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Category category)
            {
                Category categoryExist = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (categoryExist == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                    return View();

                if (await _context.Categories.AnyAsync(x => x.Id != id && x.Name.ToLower() == category.Name.Trim().ToLower()))
                {
                    ModelState.AddModelError("Name", "Category already exists!");
                    return View();
                }


                categoryExist.Name = category.Name;
                categoryExist.ModifiedDate = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }

            public async Task<IActionResult> Detail(int id)
            {
                Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }

            public async Task<IActionResult> Delete(int id)
            {
                Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null)
                {
                    return NotFound();
                }

                return View(category);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(Category categoryModel)
            {
                Category category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryModel.Id);

                if (category == null)
                {
                    return NotFound();
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }
        }
}
