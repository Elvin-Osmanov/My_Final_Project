using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restabook.Data;
using Restabook.Data.Entities;
using Restabook.Data.Enums;
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

        public IActionResult Index(int page = 1, int? categoryId = null, int? price = null, string? str = null, string? option=null)
        {
          
            double totalCount = _context.Products.Where(x => (categoryId != null ? x.CategoryId == categoryId : true)).Count();
            int pageCount = (int)Math.Ceiling(totalCount / 6);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;
            ViewBag.CategoryId = categoryId;
            ViewBag.AllProducts = _context.Products.Count();
            ViewBag.products = _context.Products.ToList();
            ViewBag.price = price;
            ViewBag.search = str;
            ViewBag.option = option;


            





            ShopViewModel shopVM = new ShopViewModel
            {
                

                Products = _context.Products.Include(x => x.ProductPhotos)
                .Skip((page - 1) * 6).Take(6).ToList(),
                Categories = _context.Categories.ToList(),
                Tags = _context.Tags.ToList(),
                PopularProducts = _context.Products.Include(x => x.ProductReviews).Where(x => x.ProductReviews.Count >= 7 && x.Rate >= 4).Take(3).ToList(),
                Searched = _context.Products.Include(x=>x.ProductPhotos).Where(x=>x.CategoryId==categoryId).ToList()
            };
            return View(shopVM);
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

