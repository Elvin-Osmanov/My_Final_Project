using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Areas.Manage.ViewModels;
using Restabook.Data;
using Restabook.Data.Entities;

namespace Restabook.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
    [Area("Manage")]
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public EventController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Events.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 5);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            EventViewModel eventVM = new EventViewModel
            {
                Events = await _context.Events.Skip((page - 1) * 5).Take(5).ToListAsync()
            };

            return View(eventVM);

        }


        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Event eventModel)
        {

     

            if (await _context.Events.AnyAsync(x => x.Title.ToLower() == eventModel.Title.Trim().ToLower()))
            {

                ModelState.AddModelError("Title", "Event already exists!");
                return View();
            }

 


            if (!ModelState.IsValid)
            {

                return View();
            }

          
            await _context.Events.AddAsync(eventModel);
            await _context.SaveChangesAsync();


            return RedirectToAction("index");
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            Event eventmodel = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);

            if (eventmodel == null)
            {
                return NotFound();
            }

           

            return View(eventmodel);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Event eventModel)
        {
            Event existEvent = await _context.Events.FirstOrDefaultAsync(x => x.Id == eventModel.Id);

            if (existEvent == null)
                return NotFound();

           

            if (await _context.Events.AnyAsync(x => x.Title.ToLower() == eventModel.Title.Trim().ToLower() && x.Id != eventModel.Id))
                return NotFound();

            

           

            existEvent.Title = eventModel.Title.Trim();
            existEvent.EventDate = eventModel.EventDate;
            existEvent.Desc = eventModel.Desc;
            existEvent.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Event eventmodel = await _context.Events.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckEventNotFound
            if (eventmodel == null)
            {
                return NotFound();
            }
            #endregion
           
            return View(eventmodel);
        }



        public async Task<IActionResult> Delete(int id)
        {
            Event eventmodel = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);

            if (eventmodel == null)
            {
                return NotFound();
            }
           
            return View(eventmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Event eventModel)
        {
            Event existevent = await _context.Events.FirstOrDefaultAsync(x => x.Id == eventModel.Id);

            if (existevent == null)
            {
                return NotFound();
            }

            _context.Events.Remove(existevent);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }


        
    }
}
