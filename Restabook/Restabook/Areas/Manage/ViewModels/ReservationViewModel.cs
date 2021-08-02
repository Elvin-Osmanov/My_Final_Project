using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Areas.Manage.ViewModels
{
    public class ReservationViewModel
    {
        public List<Reservation> Reservations { get; set; }
    }
}
