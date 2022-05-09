using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.Product
{
    public class ProductCreateVM
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double OriginalPrice { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int CateID { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
