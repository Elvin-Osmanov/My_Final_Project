using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Data;
using Restabook.Data.Entities;
using Restabook.ViewModels;

namespace Restabook.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AboutViewModel aboutVM = new AboutViewModel
            {
                Chefs = _context.Chefs.Take(3).ToList(),

                Testimonials = _context.Testimonials.Take(4).ToList(),

            };

            return View(aboutVM);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Subscribe(Subscriber subscriber)
        {
            if (subscriber.Email != null)
            {
                Subscriber sub = new Subscriber();
                if (!await _context.Subscribers.AnyAsync(x => x.Email == subscriber.Email))
                {


                    sub.CreatedDate = DateTime.UtcNow;
                    sub.ModifiedDate = DateTime.UtcNow;
                    sub.Email = subscriber.Email;


                }



                _context.Subscribers.Add(sub);

                await _context.SaveChangesAsync();
            }





            return RedirectToAction("index");
        }
    }
}
