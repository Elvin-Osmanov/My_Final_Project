using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class ProductReview:BaseEntity
    {
        public int ProductId { get; set; }

        [StringLength(maximumLength: 50),Required(ErrorMessage ="Obligatory")]
        public string FullName { get; set; }
        [StringLength(maximumLength: 50),Required(ErrorMessage = "Obligatory")]
        public string Email { get; set; }

        [StringLength(maximumLength: 500)]
        public string Message { get; set; }
        [Range(1, 5), Required(ErrorMessage = "Obligatory")]
        public int Rate { get; set; }

        public Product Product { get; set; }
    }
}
