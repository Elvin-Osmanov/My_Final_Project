using Restabook.Areas.Manage.ViewModels;
using Restabook.Data;
using Restabook.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Restabook.ViewModels;
using static Restabook.ViewModels.BasketCardViewModel;
using Newtonsoft.Json;

namespace Restabook.Services
{
    public class LayoutViewModelService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public LayoutViewModelService(AppDbContext context,UserManager<AppUser> userManager,IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public Setting GetSettings()
        {
            return _context.Settings.FirstOrDefault();
        }

        public Subscriber Subscriber { get; set; }

        public BasketCardViewModel GetBasket()
        {
            BasketCardViewModel basketVM = new BasketCardViewModel();

            var basket = _contextAccessor.HttpContext.Request.Cookies["basket"];

            List<BasketCardItemModel> basketCardItemModel = new List<BasketCardItemModel>();

            if (basket != null)
            {
                basketCardItemModel = JsonConvert.DeserializeObject<List<BasketCardItemModel>>(basket);
            }

            foreach (var basketItem in basketCardItemModel)
            {
                Product product = _context.Products.Include(x => x.ProductPhotos).FirstOrDefault(x => x.Id == basketItem.Id);


                if (product == null)
                {
                    continue;
                }



                BasketProductItemViewModel basketItemVM = new BasketProductItemViewModel
                {
                    Id = basketItem.Id,
                    Count = basketItem.Count,
                    Name = product.Name,
                    Price = product.DiscountedPrice,
                    Poster=product.PosterPhoto


                };

                basketVM.TotalPrice += product.Price * basketItem.Count;
                basketVM.BasketProductItems.Add(basketItemVM);
            }

            return basketVM;
        }




    }
}
