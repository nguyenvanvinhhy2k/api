using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel.User
{
    public class UserUpdateVM
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string role { get; set; }
        public string token { get; set; }
    }
}
