using System;
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
                taxRegistration.Approved = true;
                _dbContext.TaxRegistrations.Add(taxRegistration);
            }
        }

        public TaxRegistration getById(int id)
        {
            return _dbContext.TaxRegistrations.Find(id);
        }

        public List<TaxRegistration> getTaxRegistrations()
        {
            return _dbContext.TaxRegistrations.Local.ToList();
        }

        public void setApproved(TaxRegistration taxRegistration)
        {
            _dbContext.TaxRegistrations.Update(taxRegistration);
        }
    }
}
