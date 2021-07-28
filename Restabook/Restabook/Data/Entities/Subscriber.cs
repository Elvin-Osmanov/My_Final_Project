using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Subscriber:BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 80, ErrorMessage = "Length no more than 80!"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
    }
}
