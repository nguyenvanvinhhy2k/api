using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.StatisticalOrder
{
    public class OrderVM
    {
        public int ID { get; set; }
        public string CustemerName { get; set; }
        public string CustemerPhone { get; set; }
        public string CustemerAddress { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus Status { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderDetailVM> listorderDetail { get; set; }
    }
}
