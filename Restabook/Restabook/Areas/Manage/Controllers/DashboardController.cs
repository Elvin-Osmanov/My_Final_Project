using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Areas.Manage.ViewModels;
using Restabook.Data;

namespace Restabook.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            DashboardViewModel dVM = new DashboardViewModel
            {
                Product = _context.Products.Include(x => x.ProductPhotos).Include(x => x.Category).FirstOrDefault(x => x.HasShopped > 15),
                MostReviewed = _context.Products.Include(x => x.ProductPhotos).Include(x=>x.ProductReviews).Include(x => x.Category).FirstOrDefault(x => x.ProductReviews.Count > 4)
            };

            return View(dVM);
        }
    }
}
