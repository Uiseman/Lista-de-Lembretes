using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeLembretesAPI.Models;

namespace ListaDeLembretesAPI.Repository
{
    public interface ILembreteRepository : IRepository<Lembrete>
    {
        IEnumerable<List<Lembrete>> GetGroupedByDate();
    }
}