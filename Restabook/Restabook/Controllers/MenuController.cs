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
