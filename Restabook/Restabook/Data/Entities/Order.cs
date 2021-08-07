using Restabook.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Order:BaseEntity
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public string AppUserId { get; set; }

        public int Count { get; set; }

        public double TotalPrice { get; set; }

        public AppUser AppUser { get; set; }

        public bool IsCouponApplied { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
