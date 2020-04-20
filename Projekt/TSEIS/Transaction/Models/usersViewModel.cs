using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace Transaction.Models
{
    public class UsersViewModel
    {
        public User buyer { get; set; }
        public User seller { get; set; }
    }
}
