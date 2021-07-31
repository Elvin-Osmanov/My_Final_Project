using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class ContactMessage:BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!")]
        public string FullName { get; set; }

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Length no more than 50!"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(maximumLength: 500, ErrorMessage = "Length no more than 500!")]
        public string Subject { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string PhoneNumber { get; set; }

        [StringLength(maximumLength: 500, ErrorMessage = "Length no more than 500!")]
        [Required]
        public string Message { get; set; }

        public Contact Contact { get; set; }

        public int ContactId { get; set; }
    }
}
