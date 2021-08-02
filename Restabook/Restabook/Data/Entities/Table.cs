using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class Table:BaseEntity
    {
        public int No { get; set; }

        public DateTime Date { get; set; }

        public List<TimeTable> TimeTables { get; set; }

        [NotMapped]
        public int[] TimeIds { get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
