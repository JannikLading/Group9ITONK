using StockTraderBroker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TobinTaxingControl.Models;

namespace TobinTaxingControl.Services
{
    public class TobinTransactionService
    {
        private readonly double taxPercentage = 1.0;
        public TaxRegistration CreatetaxRegistrationFromTransaction(StockTransaction transaction)
        {
            double tax = ((transaction.TransferAmount * transaction.TransferPrice) / 100) * taxPercentage;
            transaction.TaxAmount = tax;
            return new TaxRegistration
            {
                Approved = false,
                TaxAmount = tax,
                StockTransactionId = transaction.Id,
            };
        }
    }
}
