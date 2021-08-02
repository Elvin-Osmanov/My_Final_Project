using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Restabook.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Admin_Auth")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
