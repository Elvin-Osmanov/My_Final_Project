using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.Data.Entities
{
    public class TimeTable
    {
        public int Id { get; set; }

        public Table Table { get; set; }

        public Time Time { get; set; }

        public int TableId { get; set; }

        public int TimeId { get; set; }
    }
}
