using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restabook.Data;
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
    }
}
