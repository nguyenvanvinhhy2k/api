using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.Category
{
    public class CategoryCreateVM
    {
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public int ParentID { get; set; }
    }
}
