using Backend.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.Product
{
    public class ProductRequestVM: PageRequestBase
    {
        public string keyWord { get; set; }
    }
}
