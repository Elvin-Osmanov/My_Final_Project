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
using Microsoft.AspNetCore.SignalR;
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
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHubContext<NotificationHub> _hubContext;

        public CartController(AppDbContext context, UserManager<AppUser> userManager, IHttpContextAccessor contextAccessor, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _hubContext = hubContext;
        }

        [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
        public async Task<IActionResult> Index()
        {
            string userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            Order order = await _context.Orders.Include(x => x.OrderItems).ThenInclude(x=>x.Product).ThenInclude(x => x.ProductPhotos)
                .Where(x => x.AppUserId == userId).OrderByDescending(x => x.CreatedDate).FirstOrDefaultAsync();

            ViewBag.orderId = order.Id;

            return View(order);
        }

        public async Task<IActionResult> AddBasket(int id)
        {
            Product product = _context.Products.FirstOrDefault(b => b.Id == id);

            
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

        public IActionResult RemoveBasket(int id)
        {
            List<BasketCardItemModel> baskets = new List<BasketCardItemModel>();

            

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


            _context.SaveChangesAsync();


            Response.Cookies.Append("basket", JsonConvert.SerializeObject(baskets), new CookieOptions { MaxAge = TimeSpan.FromDays(2) });

          

            return RedirectToAction("index");
        }


        [HttpPost]
        [Authorize(Roles = "Member", AuthenticationSchemes = "Member_Auth")]
        public async Task<IActionResult> Create()
        {

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            double productPrice = 0;
            Order order = new Order();
            List<OrderItem> orderItems = new List<OrderItem>();



            var orderCookies = _contextAccessor.HttpContext.Request.Cookies["basket"];

            orderItems = JsonConvert.DeserializeObject<List<OrderItem>>(orderCookies);

            foreach (var item in orderItems)
            {
                Product product = _context.Products.Include(x => x.ProductPhotos).FirstOrDefault(x => x.Id == item.Id);

                product.HasShopped++;
                if (product == null)
                {
                    continue;
                }

                OrderItem orderItem = new OrderItem
                {
                   
                    Count = item.Count,
                    Product = product,
                    CreatedDate=DateTime.UtcNow,
                    ModifiedDate=DateTime.UtcNow
                    


                };

                productPrice += item.Count  * product.DiscountedPrice;
                order.OrderItems.Add(orderItem);
            }

            

            order.TotalPrice = productPrice;
            order.CreatedDate = DateTime.UtcNow;
            order.ModifiedDate = DateTime.UtcNow;
            user.Orders.Add(order);

            Order orderin = new Order();
            await _context.Orders.AddAsync(order);
            if (_context.Orders.Count() > 0)
            {
                orderin = _context.Orders.First();

                _context.Orders.Remove(orderin);
            }
           


            await _context.SaveChangesAsync();
            List<string> adminConIds = _context.Users.Where(u => !u.IsMember).Select(x => x.ConnectionId).ToList();
            await _hubContext.Clients.Clients(adminConIds).SendAsync("OrderCreated", user.FullName,  order.CreatedDate.ToString("dd.MMMM.yyyy"));

            return RedirectToAction("index");
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

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Discount(string couponName,int Id)
        {
            Coupon coupon = await _context.Coupons.Where(x => x.CouponName.ToUpper() == couponName.ToUpper()).FirstOrDefaultAsync();

            if (coupon == null)
            {
                return NotFound();
            }
            
            Order order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == Id);
            if (!order.IsCouponApplied)
            {
               
                double discounted = order.TotalPrice * (Convert.ToDouble(coupon.CouponDiscount) / 100);
                double result = order.TotalPrice - Math.Round(discounted);
                order.IsCouponApplied = true;
                order.TotalPrice = result;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("index");
        }


    }
}
