using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.Common
{
    public class PageResultBase<T>
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalRecord { get; set; }
        public int PageCount
        {
            get
            {
                var pageCount = (double)totalRecord / pageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}
