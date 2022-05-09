using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
