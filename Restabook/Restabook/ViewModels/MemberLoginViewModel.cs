using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.ViewModels
{
    public class MemberLoginViewModel
    {

        [StringLength(maximumLength: 100), Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [StringLength(maximumLength: 20), Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
