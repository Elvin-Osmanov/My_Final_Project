using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Event:BaseEntity
    {
        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 150, ErrorMessage = "Max character is 150!")]
        public string Title { get; set; }

        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 500, ErrorMessage = "Max character is 500!")]
        public string Desc { get; set; }
    }
}
