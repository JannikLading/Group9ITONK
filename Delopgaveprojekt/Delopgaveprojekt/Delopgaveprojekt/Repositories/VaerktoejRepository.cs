using Delopgaveprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delopgaveprojekt.Repositories
{
    public class VaerktoejRepository : IVaerktoejRepository
    {
        private readonly AppDbContext.AppDbContext _dbContext;

        public VaerktoejRepository(AppDbContext.AppDbContext context)
        {
            _dbContext = context;
        }
        public void AddVaerktoej(Vaerktoej vaerktoej)
        {
            _dbContext.Vaerktoejs.Add(vaerktoej);
            _dbContext.SaveChanges();
        }
        public void DeleteVaerktoej(int id)
        {
                _dbContext.Vaerktoejs.Remove(_dbContext.Vaerktoejs.Find(id));
                _dbContext.SaveChanges();
        }
        public Vaerktoej GetById(int id)
        {
            if (id != 0)
            {
                _dbContext.Vaerktoejs.Find(id);
            }
            return null;
        }
        public List<Vaerktoej> GetVaerktoejs()
        {
            return _dbContext.Vaerktoejs.ToList();
        }

        public void UpdateVaerktoej(Vaerktoej vt)
        {
            _dbContext.Vaerktoejs.Update(vt);
            _dbContext.SaveChanges();
        }
    }
}
