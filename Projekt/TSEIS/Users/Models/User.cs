using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Models
{
    public class User
    {
        public User()
        {

        }

        [Key]
        public int Id { get; set; }

        public double Balance { get; set; }

        public string Name { get; set; }
    }
}
