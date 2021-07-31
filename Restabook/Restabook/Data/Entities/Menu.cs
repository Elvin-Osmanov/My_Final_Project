using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Menu:BaseEntity
    {
        

        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 100, ErrorMessage = "Length no more than 100!")]
        public string Name { get; set; }

        public int Order { get; set; }

        
    }
}
