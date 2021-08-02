using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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


            Subscriber sub = new Subscriber
            {
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                Email = subscriber.Email

            };

            _context.Subscribers.Add(sub);

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
