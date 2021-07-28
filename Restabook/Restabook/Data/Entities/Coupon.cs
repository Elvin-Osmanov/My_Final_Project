using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Coupon:BaseEntity
    {

        [StringLength(maximumLength: 10, ErrorMessage = "Lenght should be no more than 10 characters!!!")]
        public string CouponName { get; set; }

        public int CouponDiscount { get; set; }
    }
}
