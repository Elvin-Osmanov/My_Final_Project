using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Product:BaseEntity
    {
        [Required(ErrorMessage ="Obligatory!!!")]
        [StringLength(maximumLength: 100, ErrorMessage = "Lenght should be no more than 100 characters!!!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 200, ErrorMessage = "Max character is 200!")]
        public string SmallDesc { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [StringLength(maximumLength: 120, ErrorMessage = "Max character is 120!")]
        public string Slug { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 2000, ErrorMessage = "Max character is 2000!")]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Obligatory!!!")]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Range(0, double.MaxValue)]
        public double DiscountedPrice { get; set; }
        
        
        [Range(0, 100)]
        public double DiscountPercent { get; set; }

        public int Rate { get; set; }

        public int HasSeen { get; set; }

        public int HasShopped { get; set; }


        public List<ProductReview> ProductReviews { get; set; }

        public List<ProductTag> ProductTags { get; set; }

        [NotMapped]
        public int[] TagIds { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public bool IsChefSelecetion { get; set; }

        public List<ProductPhoto> ProductPhotos { get; set; }

        [NotMapped]
        public List<IFormFile> Files { get; set; } = new List<IFormFile>();

    

        [NotMapped]
        public List<int> FileIds { get; set; }


  
    }
}
