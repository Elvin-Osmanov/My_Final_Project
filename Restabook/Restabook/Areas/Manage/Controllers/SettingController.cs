using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restabook.Areas.Manage.ViewModels;
using Restabook.Data;
using Restabook.Data.Entities;
using Restabook.Helpers;

namespace Restabook.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SettingController : Controller
    {
        private AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {

            SettingViewModel settingVM = new SettingViewModel
            {
                Setting = await _context.Settings.FirstOrDefaultAsync()
            };
            return View(settingVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Setting setting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);

            #region CheckSlider

            if (setting == null)
            {
                return NotFound();
            }
            #endregion
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Setting setting)
        {
            Setting existSetting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == setting.Id);

            #region CheckSetting

            if (existSetting == null)
            {
                return NotFound();
            }
            #endregion

            existSetting.AboutStory = setting.AboutStory;
            existSetting.SupportPhone = setting.SupportPhone;
            existSetting.FooterDesc = setting.FooterDesc;
            existSetting.ServicePhone = setting.ServicePhone;
            existSetting.Address = setting.Address;
            existSetting.SupportEmail = setting.SupportEmail;
            existSetting.FacebookUrl = setting.FacebookUrl;
            existSetting.TwitterUrl = setting.TwitterUrl;
            existSetting.InstagramUrl = setting.InstagramUrl;
            existSetting.VkUrl = setting.VkUrl;
            existSetting.StartDay1 = setting.StartDay1;
            existSetting.StartDay2 = setting.StartDay2;
            existSetting.OverDay1 = setting.OverDay1;
            existSetting.OverDay2 = setting.OverDay2;
            existSetting.StartTime1 = setting.StartTime1;
            existSetting.StartTime2 = setting.StartTime2;
            existSetting.OverTime1 = setting.OverTime1;
            existSetting.OverTime2 = setting.OverTime2;
            existSetting.VideoRedirectUrl = setting.VideoRedirectUrl;






            #region ModelStateCheck
            if (!ModelState.IsValid)
            {
                return View(setting);
            }
            #endregion

            setting.Files.Add(setting.Header);
            setting.Files.Add(setting.Footer);
            setting.Files.Add(setting.AboutFile);

            if (setting.Header != null || setting.Footer != null || setting.AboutFile != null)
            {

                if (setting.Header != null)
                {
                    FileManagerHelper.Delete(_env.WebRootPath, "uploads/setting", existSetting.HeaderLogo);
                    setting.Files.Add(setting.Header);

                }

                if (setting.Footer != null)
                {
                    FileManagerHelper.Delete(_env.WebRootPath, "uploads/setting", existSetting.FooterLogo);
                    setting.Files.Add(setting.Footer);

                }

                if (setting.AboutFile != null)
                {
                    FileManagerHelper.Delete(_env.WebRootPath, "uploads/setting", existSetting.AboutPhoto);
                    setting.Files.Add(setting.AboutFile);

                }


                foreach (var file in setting.Files)
                {
                    #region CheckPhotoLength
                    if (file.Length > 3 * (1024 * 1024))
                    {
                        ModelState.AddModelError("File", "Cannot be more than 3MB");
                        return View();

                    }
                    #endregion
                    #region CheckPhotoContentType
                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {
                        ModelState.AddModelError("File", "Only jpeg and png files accepted");
                        return View();
                    }
                    #endregion
                    if (setting.Header != null)
                    {
                        if (file.Name.Trim().ToLower() == setting.Header.Name.Trim().ToLower())
                        {
                            string filename = FileManagerHelper.Save(_env.WebRootPath, "uploads/setting", file);
                            existSetting.HeaderLogo = filename;
                        }
                    }
                    if (setting.Footer != null)
                    {
                        if (file.Name.Trim().ToLower() == setting.Footer.Name.Trim().ToLower())
                        {
                            string fileName = FileManagerHelper.Save(_env.WebRootPath, "uploads/setting", file);
                            existSetting.FooterLogo = fileName;
                        }
                    }

                    if (setting.AboutFile != null)
                    {
                        if (file.Name.Trim().ToLower() == setting.AboutFile.Name.Trim().ToLower())
                        {
                            string fileName = FileManagerHelper.Save(_env.WebRootPath, "uploads/setting", file);
                            existSetting.AboutPhoto = fileName;
                        }
                    }


                }
            }



            await _context.SaveChangesAsync();

            return RedirectToAction("index");


        }
    }
}
