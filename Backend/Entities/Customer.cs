using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } 
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Order> orders { get; set; }
    }
}
