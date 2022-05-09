using Backend.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.Category
{
    public class CategoryRequestVM:PageRequestBase
    {
        public string keyWord { get; set; }
    }
}
