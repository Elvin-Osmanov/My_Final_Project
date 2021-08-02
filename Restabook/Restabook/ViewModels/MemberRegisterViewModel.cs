using Microsoft.AspNetCore.Mvc.Rendering;
using Restabook.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.ViewModels
{
    public class MemberRegisterViewModel
    {
        [StringLength(maximumLength: 20), Required]
        public string UserName { get; set; }

        [StringLength(maximumLength: 50), Required]
        public string FullName { get; set; }

        [StringLength(maximumLength: 100), Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(maximumLength: 50), Required]
        public string PhoneNumber { get; set; }

        [Required]
        public Gender Gender { get; set; }


        [Required]
        public DateTime Birthdate { get; set; }

        [StringLength(maximumLength: 20), Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(maximumLength: 20), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        
           
            

        
    }
}
