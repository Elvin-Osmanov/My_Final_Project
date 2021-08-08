using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restabook.Data;
using Restabook.Data.Entities;
using Restabook.Data.Enums;

namespace Restabook.Controllers
{
    [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
    public class ReservationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public ReservationController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var PersonQuantity = new List<SelectListItem>();

            List<Table> alltables = _context.Tables.Include(x => x.Reservation).ToList();
            List<Table> booked = new List<Table>();

            foreach (var item in _context.Reservations)
            {
                if (item.TableId != 0)
                {
                    Table bookedTable = await _context.Tables.FirstOrDefaultAsync(x => x.Id == item.TableId);

                    booked.Add(bookedTable);
                }
            }

            List<Table> notboked = alltables.Except(booked).ToList();

            if (booked.Count != 0)
            {
                ViewBag.times = notboked.Select(x => x.StartTime).ToList();
                ViewBag.dates = notboked.Select(x => x.Date).ToList();

            }
            else
            {
                ViewBag.times = _context.Tables.Select(x => x.StartTime).ToList();
                ViewBag.dates = _context.Tables.Select(x => x.Date).ToList();

            }


            Table table = new Table();
            foreach (var item in alltables)
            {
                if (item.Reservation.TableId == 0)
                {
                    table = item;
                }
            }

           


            foreach (var item in Enum.GetValues(typeof(PersonCount)))
            {
                PersonQuantity.Add(new SelectListItem
                {
                    Value = item.ToString(),
                    Text = Enum.GetName(typeof(PersonCount), item)

                });
            }

            ViewBag.personquantity = PersonQuantity;




            return View(table);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reserve(Reservation reservation,int id)
        {

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Table table = await _context.Tables.FirstOrDefaultAsync();


            Reservation reservationmodel = new Reservation();

                reservationmodel.AppUserId = user.Id;
                reservationmodel.TableId = reservation.TableId;
                reservationmodel.CreatedDate = DateTime.UtcNow;
                reservationmodel.PersonCount = reservation.PersonCount;
                reservationmodel.Message = reservation.Message;
                reservationmodel.CustomerName = reservation.CustomerName;
                reservationmodel.EmailAddress = reservation.EmailAddress;
                reservationmodel.PhoneNumber = reservation.PhoneNumber;
                reservationmodel.ReservationDate = reservation.ReservationDate;
                reservationmodel.Status = ReservationStatus.Pending;
                reservationmodel.ReservationTime = reservation.ReservationTime;


            await _context.Reservations.AddAsync(reservationmodel);
            await _context.SaveChangesAsync();

            return RedirectToAction("profile", "account");
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
