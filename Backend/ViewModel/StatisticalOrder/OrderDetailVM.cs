using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.StatisticalOrder
{
    public class OrderDetailVM
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
