using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restabook.Data;
using Restabook.Data.Entities;
using Restabook.Data.Enums;

namespace Restabook.Controllers
{
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public ReservationController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var PersonQuantity = new List<SelectListItem>();

            var time = new List<SelectListItem>();

            foreach (var item in _context.Times)
            {
                time.Add(new SelectListItem
                {
                    Value = item.ToString(),
                    Text = item.StartTime.ToString("HH:mm")

                });
            }

            ViewBag.Times = time;


            foreach (var item in Enum.GetValues(typeof(PersonCount)))
            {
                PersonQuantity.Add(new SelectListItem
                {
                    Value = item.ToString(),
                    Text = Enum.GetName(typeof(PersonCount), item)

                });
            }

            ViewBag.personquantity = PersonQuantity;




            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reserve(Reservation reservation)
        {

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            try
            {
                Table table = await _context.Tables.FirstOrDefaultAsync(x => x.Date == reservation.ReservationDate);


            table.Reservations = new List<Reservation>();



            

            Reservation reservationmodel = new Reservation();

            reservationmodel.AppUserId = user.Id;
            reservationmodel.CreatedDate = DateTime.UtcNow;
            reservationmodel.PersonCount = reservation.PersonCount;
            reservationmodel.Message = reservation.Message;
            reservationmodel.CustomerName = reservation.CustomerName;
            reservationmodel.EmailAddress = reservation.EmailAddress;
            reservationmodel.PhoneNumber = reservation.PhoneNumber;
            reservationmodel.ReservationDate = reservation.ReservationDate;
            reservationmodel.Status = ReservationStatus.Pending;
            reservationmodel.ReservationTime = reservation.ReservationTime;


           
                table.Reservations.Add(reservationmodel);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return View("Error");
            }
           



            return RedirectToAction("index","home");
        }
        

        public async Task<IActionResult> ProfileReservation(int id)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Reservation existRes = await _context.Reservations.FirstOrDefaultAsync(x => x.Id==id);

            if (existRes == null)
            {
                NotFound();
            }

            return View(existRes);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveReservation(Reservation reservation)
        {
            Reservation existRes =await _context.Reservations.FirstOrDefaultAsync(x => x.Id == reservation.Id);

            if (existRes == null)
            {
                NotFound();
            }

            _context.Reservations.Remove(existRes);
            await _context.SaveChangesAsync();

            return RedirectToAction("profile","account");
        
        }
     }
}
