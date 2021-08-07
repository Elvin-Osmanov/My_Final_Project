using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Areas.Manage.ViewModels;
using Restabook.Data;
using Restabook.Data.Entities;
using Restabook.Helpers;

namespace Restabook.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
    [Area("Manage")]
        public class ChefController : Controller
        {
            private readonly AppDbContext _context;
            private readonly IWebHostEnvironment _env;
            public ChefController(AppDbContext context, IWebHostEnvironment env)
            {
                _context = context;
                _env = env;
            }

            public async Task<IActionResult> Index(int page = 1)
            {
                double totalCount = await _context.Chefs.CountAsync();
                int pageCount = (int)Math.Ceiling(totalCount / 5);

                if (page < 1) page = 1;
                else if (page > pageCount) page = pageCount;

                ViewBag.PageCount = pageCount;
                ViewBag.SelectedPage = page;

                ChefViewModel chefViewModel = new ChefViewModel
                {
                    Chefs = _context.Chefs.Skip((page - 1) * 5).Take(5).ToList()
                };

                return View(chefViewModel);
            }

            public IActionResult Create()
            {

                return View();
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Chef chef)
            {


                #region ModelStateCheck
                if (!ModelState.IsValid)
                {
                    return View(chef);
                }
                #endregion

                if (chef.File != null)
                {
                    #region PhotoLengthChecking
                    if (chef.File.Length > 3 * (1024 * 1024))
                    {
                        ModelState.AddModelError("File", "Cannot be more than 3MB");
                        return View();

                    }
                    #endregion
                    #region PhotoContentTypeChecking
                    if (chef.File.ContentType != "image/png" && chef.File.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("File", "Only jpeg and png files accepted");
                        return View();
                    }
                    #endregion

                    string filename = FileManagerHelper.Save(_env.WebRootPath, "uploads/chefs", chef.File);

                chef.Photo = filename;
                }
                    chef.CreatedDate = DateTime.UtcNow;
                    chef.ModifiedDate = DateTime.UtcNow;


                await _context.Chefs.AddAsync(chef);
                await _context.SaveChangesAsync();

                return RedirectToAction("index");


            }

            public async Task<IActionResult> Edit(int id)
            {
                Chef chef = await _context.Chefs.FirstOrDefaultAsync(s => s.Id == id);

                #region CheckSlider

                if (chef == null)
                {
                    return NotFound();
                }
                #endregion
                return View(chef);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(Chef chef)
            {
                Chef existChef = await _context.Chefs.FirstOrDefaultAsync(s => s.Id == chef.Id);

                #region CheckSlider

                if (existChef == null)
                {
                    return NotFound();
                }
            #endregion

                existChef.FullName = chef.FullName;
                existChef.City = chef.City;
                existChef.Desc = chef.Desc;
                existChef.VkUrl = chef.VkUrl;
                existChef.InstagramUrl = chef.InstagramUrl;
                existChef.TwitterUrl = chef.TwitterUrl;
                existChef.FacebookUrl = chef.FacebookUrl;


            #region ModelStateCheck
            if (!ModelState.IsValid)
                {
                    return View(chef);
                }
                #endregion

                if (chef.File != null)
                {
                    #region CheckPhotoLength
                    if (chef.File.Length > 3 * (1024 * 1024))
                    {
                        ModelState.AddModelError("File", "Cannot be more than 3MB");
                        return View();

                    }
                    #endregion
                    #region CheckPhotoContentType
                    if (chef.File.ContentType != "image/png" && chef.File.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("File", "Only jpeg and png files accepted");
                        return View();
                    }
                    #endregion

                    string filename = FileManagerHelper.Save(_env.WebRootPath, "uploads/chefs", chef.File);

                    if (!string.IsNullOrWhiteSpace(existChef.Photo))
                    {
                        FileManagerHelper.Delete(_env.WebRootPath, "uploads/chefs", existChef.Photo);
                    }

                existChef.Photo = filename;
                }


                await _context.SaveChangesAsync();

                return RedirectToAction("index");


            }

            public async Task<IActionResult> Detail(int id)
            {
                Chef chef = await _context.Chefs.FirstOrDefaultAsync(s => s.Id == id);

                #region CheckChefNotFound
                if (chef == null)
                {
                    return NotFound();
                }
                #endregion

                return View(chef);
            }

            public async Task<IActionResult> Delete(int id)
            {
                Chef chef = await _context.Chefs.FirstOrDefaultAsync(s => s.Id == id);

                #region CheckChefNotFound
                if (chef == null)
                {
                    return NotFound();
                }
                #endregion

                return View(chef);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(Chef chefModel)
            {
                Chef chef = await _context.Chefs.FirstOrDefaultAsync(s => s.Id == chefModel.Id);

                #region CheckChefNotFound
                if (chef == null)
                {
                    return NotFound();
                }
                #endregion


                _context.Chefs.Remove(chef);
                await _context.SaveChangesAsync();

                return RedirectToAction("index");
            }


        }
    
}
