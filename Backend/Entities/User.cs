using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string role { get; set; }
        public string token { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
