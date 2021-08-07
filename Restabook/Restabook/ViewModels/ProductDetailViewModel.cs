using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.ViewModels
{
    public class ProductDetailViewModel
    {
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> PopularProducts { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
