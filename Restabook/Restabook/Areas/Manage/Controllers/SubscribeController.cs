using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Data;
using Restabook.Data.Entities;

namespace Restabook.Areas.Manage.Controllers
{

    [Area("Manage")]
    public class SubscribeController : Controller
    {
        private readonly AppDbContext _context;

        public SubscribeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Subscriber> subscribers = await _context.Subscribers.ToListAsync();

            return View(subscribers);
        }
    }
}
