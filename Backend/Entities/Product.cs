using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double OriginalPrice { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public int CateID { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
