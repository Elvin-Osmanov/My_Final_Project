using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restabook.ViewModels
{
    public class BasketCardViewModel
    {
        public BasketCardViewModel()
        {
            BasketProductItems = new List<BasketProductItemViewModel>();
        }
        public List<BasketProductItemViewModel> BasketProductItems { get; set; }
        public double TotalPrice { get; set; }
    

    public class BasketProductItemViewModel
    {
        public int Id { get; set; }
        public string Poster { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
    }
    public class BasketCardItemModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
    }
}
}
