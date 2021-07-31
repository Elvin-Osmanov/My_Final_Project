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
    public class MenuController : Controller
    {
        private readonly AppDbContext _context;

        public MenuController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            MenuViewModel menuVM = new MenuViewModel
            {
                Products = await _context.Products.Include(x => x.ProductPhotos).Include(x => x.Category).ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                Menus= await _context.Menus.ToListAsync(),
            };

            return View(menuVM);
        }
    }
}
