using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.ViewModels
{
    public class AboutViewModel
    {
        public List<Chef> Chefs { get; set; }

        public List<Testimonial> Testimonials { get; set; }

       
    }
}
