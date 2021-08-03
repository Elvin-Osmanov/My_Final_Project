using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Areas.Manage.ViewModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
           
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "Length is 20 characters"), Required(ErrorMessage = "Obligatory")]
        public string UserName { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Length is 50 characters"), Required(ErrorMessage = "Obligatory")]
        public string FullName { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "Length is 100 characters"), Required(ErrorMessage = "Obligatory"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Length is 50 characters"), Required(ErrorMessage = "Obligatory")]
        public string PhoneNumber { get; set; }

        

        public IList<string> Roles { get; set; }


    }
}
