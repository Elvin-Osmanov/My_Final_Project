using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restabook.Data;
using Restabook.ViewModels;

namespace Restabook.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel
            {
                Chefs = _context.Chefs.Take(3).ToList(),

                Testimonials = _context.Testimonials.Take(4).ToList(),

                Events = _context.Events.Take(3).ToList(),

                Services = _context.Services.Take(3).ToList()

            };
            return View(homeVM);
        }

        
    }
}
