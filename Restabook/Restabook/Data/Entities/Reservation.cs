using Restabook.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Reservation:BaseEntity
    {
        public int TableId { get; set; }

        public Table Table { get; set; }

        public string AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }

        [StringLength(maximumLength: 110)]
        [Required(ErrorMessage = "Obligatory")]
        public string EmailAddress { get; set; }

        [StringLength(maximumLength: 110)]
        [Required(ErrorMessage = "Obligatory")]
        public string PhoneNumber { get; set; }

        [StringLength(maximumLength: 110)]
        [Required(ErrorMessage ="Obligatory")]
        public string CustomerName { get; set; }

        [StringLength(maximumLength: 250,ErrorMessage ="max 250 characters!")]
        [Required(ErrorMessage = "Obligatory")]
        public string Message { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime ReservationTime { get; set; }

        public ReservationStatus Status { get; set; }

        public PersonCount PersonCount { get; set; }
    }
}
