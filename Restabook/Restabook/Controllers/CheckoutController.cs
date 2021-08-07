using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Data;
using Restabook.Data.Entities;
using Restabook.ViewModels;

namespace Restabook.Controllers
{
    [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CheckoutController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int id)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            Order order =await _context.Orders.FirstOrDefaultAsync(x => x.Id==id);


            return View(order);
        }


        public async Task<IActionResult> Checkout(Checkout checkout)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (!ModelState.IsValid)
            {
                return NoContent();
            }

            Checkout checkmodel = new Checkout { 

                AppUserId=user.Id,
                Name = checkout.Name,
                Email = checkout.Name,
                Phone = checkout.Phone,
                PostalCode = checkout.PostalCode,
                Country = checkout.Country,
                City = checkout.City,
                CardName = checkout.CardName,
                CardNumber = CryptoHelper.Crypto.HashPassword(checkout.CardNumber),
                CVV = CryptoHelper.Crypto.HashPassword(checkout.CVV),
                MM = CryptoHelper.Crypto.HashPassword(checkout.MM),
                YY = CryptoHelper.Crypto.HashPassword(checkout.YY),
                AdditionalNotes = checkout.AdditionalNotes,
            };

            await _context.Checkouts.AddAsync(checkmodel);
            await _context.SaveChangesAsync();

            return View();
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
