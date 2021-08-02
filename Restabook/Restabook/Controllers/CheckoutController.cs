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
        public async Task<IActionResult> IndexAsync()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            Order order =await _context.Orders.FirstOrDefaultAsync(x => x.AppUserId == user.Id);

            return View(order);
        }
    }
}
