using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Chef:BaseEntity
    {
        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 50!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength:70, ErrorMessage = "Length no more than 70!")]
        public string City { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 250, ErrorMessage = "Length no more than 70!")]
        public string Desc { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string FacebookUrl { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string InstagramUrl { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string VkUrl { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string TwitterUrl { get; set; }

       
        public string Photo { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
