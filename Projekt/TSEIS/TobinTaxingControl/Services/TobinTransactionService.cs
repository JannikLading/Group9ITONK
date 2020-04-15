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
            return new TaxRegistration
            {
                Approved = false,
                TaxAmount = ((transaction.TransferAmount * transaction.TransferPrice) / 100) * taxPercentage,
                Transaction = transaction,
            };
        }
    }
}
