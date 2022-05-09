using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.StatisticalOrder
{
    public class RevenueStatisticsVM
    {
        public int ID { get; set; }
        public string CustemerName { get; set; }
        public string CustemerPhone { get; set; }
        public string CustemerAddress { get; set; }
        public DateTime CreateDate { get; set; }
        public int TotalPrice { get; set; }
        public int PriceInterest { get; set; }
    }
}
