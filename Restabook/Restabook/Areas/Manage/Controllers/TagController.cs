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
        public class TagController : Controller
        {
            private readonly AppDbContext _context;

            public TagController(AppDbContext context)
            {
                _context = context;
            }
            public async Task<IActionResult> Index(int page = 1)
            {
                double totalCount = await _context.Tags.CountAsync();
                int pageCount = (int)Math.Ceiling(totalCount / 4);

                if (page < 1) page = 1;
                else if (page > pageCount) page = pageCount;

                ViewBag.PageCount = pageCount;
                ViewBag.SelectedPage = page;

                TagViewModel tagVM = new TagViewModel
                {
                    Tags = await _context.Tags.Skip((page - 1) * 4).Take(4).ToListAsync()
                };
                return View(tagVM);
            }

            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [AutoValidateAntiforgeryToken]
            public async Task<IActionResult> Create(Tag tag)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                if (await _context.Tags.AnyAsync(x => x.Name.ToLower() == tag.Name.ToLower()))
                {
                    ModelState.AddModelError("Name", "Tag already exists!");
                    return View();
                }

                tag.Name = tag.Name.Trim();
                tag.CreatedDate = DateTime.UtcNow;
                tag.ModifiedDate = DateTime.UtcNow;

                await _context.Tags.AddAsync(tag);
                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }

            public async Task<IActionResult> Edit(int id)
            {
                Tag tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

                if (tag == null)
                    return NotFound();

                return View(tag);
            }

            [HttpPost]
            [AutoValidateAntiforgeryToken]
            public async Task<IActionResult> Edit(Tag tag)
            {
                Tag existTag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == tag.Id);

                if (existTag == null)
                    return NotFound();

                existTag.Name = tag.Name;
                existTag.ModifiedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }

            public async Task<IActionResult> Detail(int id)
            {
                Tag tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

                if (tag == null)
                {
                    return NotFound();
                }

                return View(tag);
            }

            public async Task<IActionResult> Delete(int id)
            {
                Tag tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id);

                if (tag == null)
                {
                    return NotFound();
                }

                return View(tag);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(Tag tag)
            {
                Tag existTag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == tag.Id);

                if (existTag == null)
                {
                    return NotFound();
                }

                _context.Tags.Remove(existTag);
                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }
        }
    
}
