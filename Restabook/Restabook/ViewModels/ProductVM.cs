using Restabook.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.ViewModels
{
    public class ProductVM
    {
        public int Count { get; set; }

        public Product Product { get; set; }
    }
}
