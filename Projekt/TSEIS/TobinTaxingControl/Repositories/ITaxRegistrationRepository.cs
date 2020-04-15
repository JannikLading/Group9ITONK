using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TobinTaxingControl.Models;

namespace TobinTaxingControl.Repositories
{
    public interface ITaxRegistrationRepository
    {
        void addTaxRegistration(TaxRegistration taxRegistration);
        List<TaxRegistration> getTaxRegistrations();
        void setApproved(TaxRegistration taxRegistration);
    }
}
