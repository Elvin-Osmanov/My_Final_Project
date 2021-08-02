using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Data;
using Restabook.Data.Entities;

namespace Restabook.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
        public async Task<IActionResult> Create(Order order )
        {

            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == order.ProductId);

            if (product == null)
                return NotFound();


            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            order.AppUserId = user.Id;
            order.Price = product.DiscountedPrice;

            order.TotalPrice = order.Price * order.Count;
            order.OrderStatus = Data.Enums.OrderStatus.Pending;
            order.CreatedDate = DateTime.UtcNow;
            order.ModifiedDate= DateTime.UtcNow;


            product.HasShopped++;
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return RedirectToAction("index","cart");
        }
    }
}
