﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PublicShareOwnerControl.Models
{
    public class StockTrader
    {
        public StockTrader()
        {

        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public StockPortefolio Portefolio { get; set; }
    }
}
