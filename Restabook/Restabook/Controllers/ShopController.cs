using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Data;
using Restabook.ViewModels;

namespace Restabook.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page=1,int? categoryId=null)
        {
            double totalCount = _context.Products.Where(x => (categoryId != null ? x.CategoryId == categoryId : true)).Count();
            int pageCount = (int)Math.Ceiling(totalCount / 1);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;
            ViewBag.CategoryId = categoryId;
            
            ShopViewModel shopVM = new ShopViewModel
            {
                Products = _context.Products.Include(x => x.ProductPhotos).ToList(),
                Categories = _context.Categories.ToList(),
                Tags = _context.Tags.ToList()
                

            };
            return View(shopVM);
        }


    }
}
