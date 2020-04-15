﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TobinTaxingControl.Database;
using TobinTaxingControl.Models;

namespace TobinTaxingControl.Repositories
{
    public class TaxRegistrationRepository : ITaxRegistrationRepository
    {
        private readonly AppDbContext _dbContext;

        public TaxRegistrationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void addTaxRegistration(TaxRegistration taxRegistration)
        {
            if (taxRegistration != null)
            {
                _dbContext.TaxRegistrations.Add(taxRegistration);
            }
            
        }

        public List<TaxRegistration> getTaxRegistrations()
        {
            return _dbContext.TaxRegistrations.ToList();
        }

        public void setApproved(TaxRegistration taxRegistration)
        {
            _dbContext.TaxRegistrations.Update(taxRegistration);
        }
    }
}