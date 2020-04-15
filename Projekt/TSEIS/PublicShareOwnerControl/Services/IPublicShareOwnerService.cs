using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicShareOwnerControl.Services
{
    public interface IPublicShareOwnerService
    {
        void AddUser();
        void UpdateUser();
        void GetStocksByOwner(int userId);
        void DeleteUser();
    }
}
