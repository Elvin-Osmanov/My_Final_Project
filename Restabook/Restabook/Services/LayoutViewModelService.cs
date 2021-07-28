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

namespace Restabook.Services
{
    public class LayoutViewModelService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

       

      

        public LayoutViewModelService(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Setting GetSettings()
        {
            return _context.Settings.FirstOrDefault();
        }


        
       

    }
}
