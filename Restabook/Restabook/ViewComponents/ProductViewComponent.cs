using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Data;
using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, int? categoryId = null,string str=null,int?price=null, string? option = null)
        {
            List<Product> products = new List<Product>();

            switch (option)
            {
                case "PriceHighToLow":
                    products = _context.Products
               .Where(x => (categoryId != null ? x.CategoryId == categoryId : true)).Where(x => (str != null ? x.Name.ToLower().Contains(str.ToLower()) : true))
               .Where(x => (price != null ? x.Price < price : true))
               .Include(x => x.Category).Include(x => x.ProductPhotos).Include(x => x.ProductReviews)
               .Include(x => x.ProductTags).ThenInclude(x => x.Tag)
               .OrderByDescending(x => x.Price)
               .Skip((page - 1) * 6).Take(6).ToList();
                    break;
                case "AverageRating":
                    products = _context.Products
              .Where(x => (categoryId != null ? x.CategoryId == categoryId : true)).Where(x => (str != null ? x.Name.ToLower().Contains(str.ToLower()) : true))
              .Where(x => (price != null ? x.Price < price : true)).Where(x => x.Rate == 3)
              .Include(x => x.Category).Include(x => x.ProductPhotos).Include(x => x.ProductReviews)
              .Include(x => x.ProductTags).ThenInclude(x => x.Tag)
              .Skip((page - 1) * 6).Take(6).ToList();
                    break;
                case "PriceLowToHigh":
                    products = _context.Products
                  .Where(x => (categoryId != null ? x.CategoryId == categoryId : true)).Where(x => (str != null ? x.Name.ToLower().Contains(str.ToLower()) : true))
                  .Where(x => (price != null ? x.Price < price : true))
                  .Include(x => x.Category).Include(x => x.ProductPhotos).Include(x => x.ProductReviews)
                  .Include(x => x.ProductTags).ThenInclude(x => x.Tag)
                  .OrderBy(x => x.Price)
                  .Skip((page - 1) * 6).Take(6).ToList();
                    break;
                default:
                    products = _context.Products
                .Where(x => (categoryId != null ? x.CategoryId == categoryId : true)).Where(x => (str != null ? x.Name.ToLower().Contains(str.ToLower()) : true))
                .Where(x => (price != null ? x.Price < price : true))
                .Include(x => x.Category).Include(x => x.ProductPhotos).Include(x => x.ProductReviews)
                .Include(x => x.ProductTags).ThenInclude(x => x.Tag)
                .OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * 6).Take(6).ToList();
                    break;
            }
           
            return await Task.FromResult((IViewComponentResult)View("Default", products));
        }
    }
}
