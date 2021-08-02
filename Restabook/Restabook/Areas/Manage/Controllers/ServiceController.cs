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
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ServiceController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            double totalCount = await _context.Services.CountAsync();
            int pageCount = (int)Math.Ceiling(totalCount / 4);

            if (page < 1) page = 1;
            else if (page > pageCount) page = pageCount;

            ViewBag.PageCount = pageCount;
            ViewBag.SelectedPage = page;

            ServiceViewModel serviceVM = new ServiceViewModel
            {
                Services = await _context.Services.Skip((page - 1) * 4).Take(4).ToListAsync()
            };
            return View(serviceVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (await _context.Services.AnyAsync(x => x.Title.ToLower() == service.Title.ToLower()))
            {
                ModelState.AddModelError("Name", "Service already exists!");
                return View();
            }

            if (service.File != null)
            {
                #region CheckPhotoLength
                if (service.File.Length > 3 * (1024 * 1024))
                {
                    ModelState.AddModelError("File", "Cannot be more than 3MB");
                    return View();

                }
                #endregion
                #region CheckPhotoContentType
                if (service.File.ContentType != "image/png" && service.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManagerHelper.Save(_env.WebRootPath, "uploads/services", service.File);

                service.BackgroundPhoto = filename;
            }

            service.Title = service.Title.Trim();
            service.CreatedDate = DateTime.UtcNow;
            service.ModifiedDate = DateTime.UtcNow;
           

            await _context.Services.AddAsync(service);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Service service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);

            if (service == null)
                return NotFound();

            return View(service);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Service service)
        {
            Service existService = await _context.Services.FirstOrDefaultAsync(x => x.Id == service.Id);

            if (existService == null)
                return NotFound();

            existService.Title = service.Title;
            existService.Desc = service.Desc;
            existService.Icon = service.Icon;
            existService.ModifiedDate = DateTime.UtcNow;

            if (service.File != null)
            {
                #region CheckPhotoLength
                if (service.File.Length > 3 * (1024 * 1024))
                {
                    ModelState.AddModelError("File", "Cannot be more than 3MB");
                    return View();

                }
                #endregion


                #region CheckPhotoContentType
                if (service.File.ContentType != "image/png" && service.File.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("File", "Only jpeg and png files accepted");
                    return View();
                }
                #endregion

                string filename = FileManagerHelper.Save(_env.WebRootPath, "uploads/services", existService.File);

                if (!string.IsNullOrWhiteSpace(existService.BackgroundPhoto))
                {
                    FileManagerHelper.Delete(_env.WebRootPath, "uploads/services", existService.BackgroundPhoto);
                }

                existService.BackgroundPhoto = filename;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Service service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);


            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Service service = await _context.Services.FirstOrDefaultAsync(x => x.Id == id);

            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Service service)
        {
            Service existService = await _context.Services.FirstOrDefaultAsync(x => x.Id == service.Id);

            if (existService == null)
            {
                return NotFound();
            }

            _context.Services.Remove(existService);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
    }
}
