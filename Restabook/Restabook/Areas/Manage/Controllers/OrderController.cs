using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Data;
using Restabook.Data.Entities;

namespace Restabook.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
    [Area("Manage")]
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Order> orders = await _context.Orders.Include(x => x.AppUser).ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Order order = await _context.Orders
                .Include(x => x.AppUser)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Accept(int id)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return NotFound();

            order.OrderStatus = Data.Enums.OrderStatus.Accepted;
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            Order order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
                return NotFound();

            order.OrderStatus = Data.Enums.OrderStatus.Rejected;
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
