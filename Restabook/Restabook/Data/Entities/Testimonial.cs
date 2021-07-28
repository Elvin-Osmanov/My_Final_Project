using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Testimonial:BaseEntity
    {
        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 100, ErrorMessage = "Max character is 100!")]
        public string Fullname { get; set; }

        public int GivenRating { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 400, ErrorMessage = "Max character is 400!")]
        public string Desc { get; set; }


        
        public string ProfilePhoto { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
