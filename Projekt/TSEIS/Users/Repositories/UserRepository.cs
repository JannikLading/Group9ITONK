using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;
using Users.Database;

namespace Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            if (_dbContext.Users.Count() == 0)
            {
                _dbContext.LoadDefaultData();
                _dbContext.SaveChanges();
            }
        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            _dbContext.Users.Remove(_dbContext.Users.Find(id));
            _dbContext.SaveChanges();
        }

        public User GetById(int id)
        {
            if (id != 0)
            {
                return _dbContext.Users.Find(id);
            }
            return null;
        }

        public List<User> GetUsers()
        {
            var stocks = new List<User>();
            try
            {
                stocks = _dbContext.Users.ToList();
            }
            catch (Exception)
            {
                //Error accured
            }
            return stocks;
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }
    }
}
