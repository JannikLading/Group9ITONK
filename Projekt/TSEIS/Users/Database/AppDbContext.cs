using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Users.Models;
using System.Linq;

namespace Users.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public void LoadDefaultData()
        {
            User oleBent = new User { Name = "Ole Bent", Balance = 10000.00 };
            User bentOle = new User { Name = "Bent Ole", Balance = 10000.00 };
            User JohnUlrik = new User { Name = "John Ulrik", Balance = 10000.00 };
            User IngeLis = new User { Name = "Inge Lis", Balance = 1000.00 };
            User Jannik = new User { Name = "Jannik", Balance = 100000.00 };
            User Tobias = new User { Name = "Tobias", Balance = 1000.00 };
            User Nichlaes = new User { Name = "Nichlaes", Balance = 1000.00 };
            Users.Add(oleBent);
            Users.Add(bentOle);
            Users.Add(JohnUlrik);
            Users.Add(IngeLis);
            Users.Add(Jannik);
            Users.Add(Tobias);
            Users.Add(Nichlaes);
        }
    }
}
