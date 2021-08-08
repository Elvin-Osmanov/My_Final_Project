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
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Search(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return View();
            }

            ShopViewModel shopView = new ShopViewModel
            {
                Products = _context.Products.Include(x => x.ProductPhotos)
                .Include(x => x.Category).Include(x => x.ProductTags).ThenInclude(x => x.Tag).
                Where(x => x.Name.ToLower().Contains(str.ToLower())).ToList()
            };

            return View(shopView);
        }

           

            


        
    }
}
