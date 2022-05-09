using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        public string CustemerName { get; set; }
        public string CustemerPhone { get; set; }
        public string CustemerAddress { get; set; }
        public DateTime CreateDate { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
        public Customer Customer { get; set; }
    }
}
