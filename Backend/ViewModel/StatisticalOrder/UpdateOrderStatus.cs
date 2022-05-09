using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.StatisticalOrder
{
    public class UpdateOrderStatus
    {
        public int ID { get; set; }
        public OrderStatus status { get; set; }
    }
}
