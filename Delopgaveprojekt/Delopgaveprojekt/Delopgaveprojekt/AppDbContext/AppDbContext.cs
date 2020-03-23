using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delopgaveprojekt.Models;
using Microsoft.EntityFrameworkCore;

namespace Delopgaveprojekt.AppDbContext
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            LoadDefaultData();
        }
        public DbSet<Haandvaerker> Haandvaerkers { get; set; }
        public DbSet<Vaerktoej> Vaerktoejs { get; set; }
        public DbSet<Vaerktoejskasse> Vaerktoejskasses { get; set; }

        public void LoadDefaultData()
        {
            List<Vaerktoejskasse> vaerktøj = new List<Vaerktoejskasse>{ new Vaerktoejskasse 
            { VTKFarve = "grøn" } 
            };
            Haandvaerkers.Add(new Haandvaerker { HaandvaerkerId = 0, HVAnsaettelsedato = DateTime.Now, HVEfternavn = "durr", HVFagomraade = "kontanthjælp", HVFornavn = "hurr", Vaerktoejskasse=vaerktøj.ToHashSet() });
            Vaerktoejs.Add(new Vaerktoej { VTId = 0, VTAnskaffet = DateTime.Now, VTSerienr = "", VTModel = "test", VTType = "test", VTFabrikat = "" });
        }
    }
}
