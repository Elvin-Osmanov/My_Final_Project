﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IViewComponentResult> InvokeAsync(int page = 1, int? categoryId = null)
        {
            List<Product> products = _context.Products
                .Where(x => (categoryId != null ? x.CategoryId == categoryId : true))
                .Include(x => x.Category).Include(x=>x.ProductPhotos)
                .Include(x => x.ProductTags).ThenInclude(x => x.Tag)
                .OrderByDescending(x => x.CreatedDate)
                .Skip((page - 1) * 9).Take(9).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", products));
        }
    }
}