using Restabook.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Order:BaseEntity
    {
        public string AppUserId { get; set; }

        public int Count { get; set; }

        public double Price { get; set; }

        public double ShippingPrice { get; set; }

        public double TotalPrice { get; set; }

        public AppUser AppUser { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
