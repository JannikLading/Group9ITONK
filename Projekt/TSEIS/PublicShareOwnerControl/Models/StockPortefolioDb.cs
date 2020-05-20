using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicShareOwnerControl.Models
{
    public class StockPortefolioDb
    {
        public StockPortefolioDb()
        {

        }

        [Key]
        public int Id { get; set; }
        public string StockShares { get; set; }
        public int TotalAmount { get; set; }
        public double TotalPrice { get; set; }
    }
}
