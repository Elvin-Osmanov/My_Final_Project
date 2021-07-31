using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.ViewModels
{
    public class ShopViewModel
    {
        public List<Tag> Tags { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> PopularProducts { get; set; }
        public List<Product> Searched { get; set; }
    }
}
