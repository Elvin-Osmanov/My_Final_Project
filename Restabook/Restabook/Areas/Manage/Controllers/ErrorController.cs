using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Restabook.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ErrorController : Controller
    {
        [Route("Manage/Error/{statusCode}")]
        public IActionResult HttpCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Not Found";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Server Error";
                    break;
            }

            return View("Error");
        }
    }
}
