using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.ViewModels
{
    public class HomeViewModel
    {

        public List<Chef> Chefs { get; set; }

        public List<Testimonial> Testimonials { get; set; }

        public List<Event> Events { get; set; }

        public List<Service> Services { get; set; }

        public List<Product> Products { get; set; }

        

    }
}
