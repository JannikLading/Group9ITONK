using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        List<User> GetUsers();
        User GetById(int id);
        void DeleteUser(int id);
    }
}
