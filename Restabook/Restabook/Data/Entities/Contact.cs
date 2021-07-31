using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Contact:BaseEntity
    {

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Address { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Phone { get; set; }


        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string SupportEmail { get; set; }

        public List<ContactMessage> ContactMessages { get; set; }
    }
}
