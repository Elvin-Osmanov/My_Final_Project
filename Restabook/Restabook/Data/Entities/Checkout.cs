using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Checkout:BaseEntity
    {
        public string AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        [Required(ErrorMessage ="Obligatory"),StringLength(maximumLength:120,ErrorMessage ="Max 120 character")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Obligatory"), StringLength(maximumLength: 120, ErrorMessage = "Max 120 character")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obligatory"), StringLength(maximumLength: 120, ErrorMessage = "Max 120 character")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Obligatory"), StringLength(maximumLength: 60, ErrorMessage = "Max 60 character")]
        public string City { get; set; }

        [Required(ErrorMessage = "Obligatory"), StringLength(maximumLength: 60, ErrorMessage = "Max 60 character")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Obligatory"), StringLength(maximumLength: 10, ErrorMessage = "Max 10 character")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Obligatory"), StringLength(maximumLength: 120, ErrorMessage = "Max 120 character")]
        public string CardName { get; set; }

        [Required(ErrorMessage = "Obligatory")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Obligatory") ]
        public string MM { get; set; }

        [Required(ErrorMessage = "Obligatory")]
        public string YY { get; set; }

        [Required(ErrorMessage = "Obligatory")]
        public string CVV { get; set; }

        [StringLength(maximumLength: 250, ErrorMessage = "Max 250 character")]
        public string AdditionalNotes { get; set; }
    }
}
