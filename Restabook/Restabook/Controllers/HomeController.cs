using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Restabook.Data;
using Restabook.Data.Entities;
using Restabook.Data.Enums;
using Restabook.ViewModels;

namespace Restabook.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public HomeController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Chefs = _context.Chefs.Take(3).ToList(),

                Testimonials = _context.Testimonials.Take(4).ToList(),

                Events = _context.Events.Take(3).ToList(),

                Services = _context.Services.Take(3).ToList(),

                Products = _context.Products.Include(x => x.Category).ToList(),



            };
            return View(homeVM);
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
