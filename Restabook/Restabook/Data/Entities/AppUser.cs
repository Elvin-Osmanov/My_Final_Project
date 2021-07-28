using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }

        public bool IsMember { get; set; }

        public bool IsActive { get; set; }
    }
}
