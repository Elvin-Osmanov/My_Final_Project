using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Areas.Manage.ViewModels;
using Restabook.Data;
using Restabook.Data.Entities;

namespace Restabook.Areas.Manage.Controllers
{
    
        [Area("Manage")]
        public class CouponController : Controller
        {
            private readonly AppDbContext _context;

            public CouponController(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IActionResult> Index(int page = 1)
            {
                double totalCount = await _context.Categories.CountAsync();
                int pageCount = (int)Math.Ceiling(totalCount / 5);

                if (page < 1) page = 1;
                else if (page > pageCount) page = pageCount;

                ViewBag.PageCount = pageCount;
                ViewBag.SelectedPage = page;

            CouponViewModel couponVM = new CouponViewModel
            {
                    Coupons = await _context.Coupons.Skip((page - 1) * 5).Take(5).ToListAsync()
                };
                return View(couponVM);
            }

            public async Task<IActionResult> Create()
            {
                Coupon coupon = await _context.Coupons.FirstOrDefaultAsync();

                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Coupon coupon)
            {
                if (!ModelState.IsValid)
                    return View();

                    coupon.CouponName = coupon.CouponName.Trim().ToUpper();
                    coupon.CreatedDate = DateTime.UtcNow;
                    coupon.ModifiedDate = DateTime.UtcNow;

                await _context.Coupons.AddAsync(coupon);

                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }

            public async Task<IActionResult> Edit(int id)
            {
            Coupon coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == id);

                if (coupon == null)
                {
                    return NotFound();
                }

                return View(coupon);
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(Coupon coupon)
            {
                Coupon existCoupon = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == coupon.Id);

                if (existCoupon == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                    return View();

            existCoupon.CouponDiscount = coupon.CouponDiscount;
            existCoupon.CouponName = coupon.CouponName;
                    existCoupon.ModifiedDate = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }

            public async Task<IActionResult> Detail(int id)
            {
                Coupon coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == id);


                if (coupon == null)
                {
                    return NotFound();
                }

                return View(coupon);
            }

            public async Task<IActionResult> Delete(int id)
            {
            Coupon coupon = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == id);

                if (coupon == null)
                {
                    return NotFound();
                }

                return View(coupon);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(Coupon coupon)
            {
                Coupon existCoupon = await _context.Coupons.FirstOrDefaultAsync(x => x.Id == coupon.Id);

                if (existCoupon == null)
                {
                    return NotFound();
                }

                _context.Coupons.Remove(existCoupon);
                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }

        }
    
}
