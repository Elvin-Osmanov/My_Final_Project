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
    public class TimeController : Controller
    {
        private readonly AppDbContext _context;

        public TimeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Times.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            TimeViewModel timeVM = new TimeViewModel
            {
                Times = await _context.Times.Skip((page - 1) * 5).Take(5).ToListAsync()
            };
            return View(timeVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Time time)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (await _context.Times.AnyAsync(x => x.StartTime.Hour==time.StartTime.Hour))
            {
                ModelState.AddModelError("Time", "Time already exists!");
                return View();
            }


            time.EndTime = time.StartTime.AddHours(2);
           

            await _context.Times.AddAsync(time);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Time time = await _context.Times.FirstOrDefaultAsync(x => x.Id == id);

            if (time == null)
                return NotFound();

            return View(time);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Time time)
        {
            Time existTime = await _context.Times.FirstOrDefaultAsync(x => x.Id == time.Id);

            if (existTime == null)
                return NotFound();

            existTime.StartTime = time.StartTime;
            existTime.EndTime = time.StartTime.AddHours(2);
           

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Time time = await _context.Times.FirstOrDefaultAsync(x => x.Id == id);

            if (time == null)
            {
                return NotFound();
            }

            return View(time);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Time time = await _context.Times.FirstOrDefaultAsync(x => x.Id == id);

            if (time == null)
            {
                return NotFound();
            }

            return View(time);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Time time)
        {
            Time existTime = await _context.Times.FirstOrDefaultAsync(x => x.Id == time.Id);

            if (existTime == null)
            {
                return NotFound();
            }

            _context.Times.Remove(existTime);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
