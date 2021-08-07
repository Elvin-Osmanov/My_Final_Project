using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Restabook.Data;
using Restabook.Data.Entities;
using Restabook.ViewModels;

namespace Restabook.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }



        //[HttpPost]
        //[Route("/order/create")]
        //[Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
        //public async Task<IActionResult> Create()
        //{

        //    AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
        //    double productPrice = 0;
        //    Order order = new Order();
        //    List<OrderItem> orderItems = new List<OrderItem>();



        //    var orderCookies = _contextAccessor.HttpContext.Request.Cookies["basket"];

        //    orderItems = JsonConvert.DeserializeObject<List<OrderItem>>(orderCookies);

        //    foreach (var item in orderItems)
        //    {
        //        Product product = _context.Products.Include(x => x.ProductPhotos).FirstOrDefault(x => x.Id == item.Id);


        //        if (product == null)
        //        {
        //            continue;
        //        }

        //        OrderItem orderItem = new OrderItem
        //        {
        //            Id = item.Id,
        //            Count = item.Count,
        //            Product = product
                  


        //        };

        //        productPrice += item.Count * product.DiscountedPrice;
        //        order.OrderItems.Add(orderItem);
        //    }


        //    user.Orders.Add(order);

        //    await _context.Orders.AddAsync(order);
        //    await _context.SaveChangesAsync();


        //    return View("index", order);
        //}
    }
}
