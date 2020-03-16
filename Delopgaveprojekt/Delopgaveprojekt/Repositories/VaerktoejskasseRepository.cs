using Delopgaveprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delopgaveprojekt.Repositories
{
    public class VaerktoejskasseRepository : IVaerktoejskasseRepository
    {
        private readonly AppDbContext.AppDbContext _dbContext;

        public VaerktoejskasseRepository(AppDbContext.AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddVaerktoejskasse(Vaerktoejskasse vaerktoejskasse)
        {
            if (vaerktoejskasse != null)
            {
                _dbContext.Vaerktoejskasses.Add(vaerktoejskasse);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteVaerktoejskasse(int id)
        {
            _dbContext.Vaerktoejskasses.Remove(_dbContext.Vaerktoejskasses.Find(id));
            _dbContext.SaveChanges();
        }

        public Vaerktoejskasse GetById(int id)
        {
            if (id != 0)
            {
                _dbContext.Vaerktoejskasses.Find(id);
            }
            return null;
        }

        public List<Vaerktoejskasse> GetVaerktoejskasses()
        {
            return _dbContext.Vaerktoejskasses.ToList();
        }

        public void UpdateVaerktoejskasse(int id)
        {
            _dbContext.Vaerktoejskasses.Update(_dbContext.Vaerktoejskasses.Find(id));
            _dbContext.SaveChanges();
        }
    }
}
