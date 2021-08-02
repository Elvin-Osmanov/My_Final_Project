using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using static Restabook.ViewModels.BasketCardViewModel;

namespace Restabook.Controllers
{
    [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CartController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
        public async Task<IActionResult> Index()
        {
            string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            List<Order> orders = await _context.Orders.Include(x => x.Product).ThenInclude(x => x.ProductPhotos)
                .Where(x => x.AppUserId == userId).OrderByDescending(x => x.CreatedDate).ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> Remove(Order order)
        {
            Order orderExist = await _context.Orders.FirstOrDefaultAsync(x => x.Id == order.Id);

            if (order == null)
            {
                NotFound();
            }

            _context.Orders.Remove(orderExist);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> AddBasket(int id,Order order)
        {
            Product product = _context.Products.FirstOrDefault(b => b.Id == id);
            //Product productOrder = _context.Products.FirstOrDefault(p => p.Id == order.ProductId);

            //if (product == null)
            //{
            //    return RedirectToAction("index");
            //}

            //if (productOrder == null)
            //    return NotFound();

            //AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            //order.AppUserId = user.Id;
            //order.Price = product.DiscountedPrice;
            
            //order.TotalPrice = order.Price*order.Count;
            //order.OrderStatus = Data.Enums.OrderStatus.Pending;
            //order.CreatedDate = DateTime.UtcNow;
            //order.ModifiedDate = DateTime.UtcNow;

            List<BasketCardItemModel> baskets = new List<BasketCardItemModel>();

            if (Request.Cookies["basket"] == null)
            {

                BasketCardItemModel basketCardItemModel = new BasketCardItemModel
                {
                    Id = id,
                    Count = 1,
                };
                baskets.Add(basketCardItemModel);

               
            }
            else
            {
                baskets = JsonConvert.DeserializeObject<List<BasketCardItemModel>>(Request.Cookies["basket"]);

                if (baskets.Any(b => b.Id == id))
                {
                    BasketCardItemModel existBasketItem = baskets.FirstOrDefault(b => b.Id == id);
                    existBasketItem.Count += 1;
                }
                else
                {
                    BasketCardItemModel basketCardItemModel = new BasketCardItemModel
                    {
                        Id = id,
                        Count = 1,
                    };
                    baskets.Add(basketCardItemModel);
                }
            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(baskets), new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
            //await _context.Orders.AddAsync(order);
            //await _context.SaveChangesAsync();

            return RedirectToAction("index","shop");
        }

        public IActionResult Basket()
        {
            var basket = Request.Cookies["basket"];
            List<BasketCardItemModel> baskets = new List<BasketCardItemModel>();

            if (basket != null)
            {
                baskets = JsonConvert.DeserializeObject<List<BasketCardItemModel>>(basket);
            }

            return Json(baskets);
        }

        public IActionResult RemoveBasket(int id,Order order)
        {
            List<BasketCardItemModel> baskets = new List<BasketCardItemModel>();

            //Order orderExist =  _context.Orders.FirstOrDefault(x => x.Id == order.Id);

            //if (order == null)
            //{
            //    NotFound();
            //}

            //_context.Orders.Remove(orderExist);
            // _context.SaveChanges();

            if (Request.Cookies["basket"] != null)
            {
                baskets = JsonConvert.DeserializeObject<List<BasketCardItemModel>>(Request.Cookies["basket"]);
                if (baskets.Any(b => b.Id == id))
                {
                    BasketCardItemModel basketItem = baskets.FirstOrDefault(b => b.Id == id);
                    if (basketItem.Count > 1)
                    {
                        basketItem.Count -= 1;

                    }
                    else
                    {
                        baskets.Remove(basketItem);
                    }
                }

            }

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(baskets), new CookieOptions { MaxAge = TimeSpan.FromDays(2) });

            return RedirectToAction("index");
        }


        

    }
}
