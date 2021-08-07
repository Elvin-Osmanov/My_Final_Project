using Microsoft.AspNetCore.Identity;
using Restabook.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class AppUser:IdentityUser
    {

        public AppUser()
        {
            Orders = new List<Order>();
            Reservations = new List<Reservation>();
        }

        [StringLength(maximumLength: 50)]
        public string FullName { get; set; }

        public bool IsMember { get; set; }

        public bool IsActive { get; set; }

        public List<Order> Orders { get; set; }

        public List<Checkout> Checkouts { get; set; }

        public List<Reservation> Reservations { get; set; }


        public Gender Gender { get; set; }


        public string ConnectionId { get; set; }

        public bool IsConnected { get; set; }

        public DateTime Birthdate { get; set; }

        [NotMapped]
        [StringLength(maximumLength: 20), DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [NotMapped]
        [StringLength(maximumLength: 20), DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [StringLength(maximumLength: 20), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
