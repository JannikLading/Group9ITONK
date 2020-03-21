using Delopgaveprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delopgaveprojekt.Repositories
{
    public interface IHaandvaerkerRepository
    {
        void AddHaandvaerker(Haandvaerker haandvaerker);
        List<Haandvaerker> GetHaandvaerkers();
        Haandvaerker GetById(int id);
        void UpdateHaandvaerker(Haandvaerker hv);
        void DeleteHaandvaerker(int id);
    }
}
