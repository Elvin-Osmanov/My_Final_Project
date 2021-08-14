using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Areas.Manage.ViewModels
{
    public class DashboardViewModel
    {
        public Product Product { get; set; }

        public Product MostReviewed { get; set; }
    }
}
