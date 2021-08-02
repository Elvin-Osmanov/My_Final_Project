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
    public class ReservationController : Controller
    {

        private readonly AppDbContext _context;

        public ReservationController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Reservations.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 4);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            ReservationViewModel reservVM = new ReservationViewModel
            {
                Reservations = await _context.Reservations.Skip((page - 1) * 4).Take(4).ToListAsync()
            };
            return View(reservVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Reservation res = await _context.Reservations
                .Include(x => x.AppUser)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
                return NotFound();

            return View(res);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Accept(int id)
        {
            Reservation res = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
                return NotFound();

            res.Status = Data.Enums.ReservationStatus.Accepted;
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            Reservation res = await _context.Reservations.FirstOrDefaultAsync(x => x.Id == id);

            if (res == null)
                return NotFound();

            res.Status = Data.Enums.ReservationStatus.Rejected;
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
