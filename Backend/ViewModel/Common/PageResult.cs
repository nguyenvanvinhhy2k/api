using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.Common
{
    public class PageResult<T>: PageResultBase<T>
    {
        public List<T> items { get; set; }
    }
}
