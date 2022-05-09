using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int SortOrder { get; set; }
        public int ParentID { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Product> Products { get; set; }
        
    }
}
