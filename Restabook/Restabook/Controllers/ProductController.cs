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
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id, int?categoryId=null)
        {
            ViewBag.CategoryId = categoryId;

            Product product = await _context.Products
                   .Include(x => x.ProductPhotos)
                   .Include(x => x.Category)
                   .Include(x => x.ProductReviews)
                   .Include(x => x.ProductTags).ThenInclude(x => x.Tag)
                   .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
                return NotFound();

            

            ProductDetailViewModel productVM = new ProductDetailViewModel
            {
                Product = product,
                RelatedProducts = await _context.Products
                 .Include(x => x.Category).Include(x => x.ProductTags).ThenInclude(x => x.Tag).Include(x => x.ProductPhotos)
                 .Where(x => x.CategoryId == product.CategoryId && x.Name != product.Name).OrderByDescending(x => x.CreatedDate).Take(3).ToListAsync(),
                Products = await _context.Products.ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),

                PopularProducts = await _context.Products.Include(x => x.ProductPhotos).Where(x => x.ProductReviews.Count >= 7 && x.Rate >= 4).Take(3).ToListAsync(),
            };

            product.HasSeen++;
            await _context.SaveChangesAsync();

            return View(productVM);
        }


         

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Review(ProductReview review)
        {
            Product product = await _context.Products.Include(x => x.ProductReviews).FirstOrDefaultAsync(x => x.Id == review.ProductId);

            if (product == null)
                return NotFound();


            ProductReview productReview = new ProductReview
            {
                CreatedDate = DateTime.UtcNow,
                Email = review.Email,
                FullName = review.FullName,
                Rate = review.Rate,
                ProductId = review.ProductId,
                Message = review.Message
            };

            product.ProductReviews.Add(productReview);
            product.Rate = product.ProductReviews.Sum(x => x.Rate) / product.ProductReviews.Count();

            await _context.SaveChangesAsync();

            return Ok();
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
