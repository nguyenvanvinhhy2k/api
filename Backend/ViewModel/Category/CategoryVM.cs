using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.Category
{
    public class CategoryVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int SortOrder { get; set; }
        public int ParentID { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
