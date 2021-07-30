using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Tag:BaseEntity
    {
        [Required(ErrorMessage = ("Obligatory!!!"))]
        [StringLength(maximumLength: 30, ErrorMessage = "Length no more than 30!")]
        public string Name { get; set; }

        public List<ProductTag> ProductTags { get; set; }
    }
}
