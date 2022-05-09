using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.Cart
{
    public class OrderDetailCreateVM
    {
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
