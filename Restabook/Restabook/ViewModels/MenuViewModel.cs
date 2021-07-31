using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.ViewModels
{
    public class MenuViewModel
    {
        public List<Product> Products { get; set; }

        public List<Menu> Menus { get; set; }

        public List<Category> Categories { get; set; }
    }
}
