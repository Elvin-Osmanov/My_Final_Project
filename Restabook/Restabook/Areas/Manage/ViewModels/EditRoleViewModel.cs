using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Areas.Manage.ViewModels
{
    public class EditRoleViewModel

        
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage ="Role is Required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
