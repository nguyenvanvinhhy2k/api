using Backend.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.StatisticalOrder
{
    public class OrderRequest:PageRequestBase
    {
        public string keyWord { get; set; }
    }
}
