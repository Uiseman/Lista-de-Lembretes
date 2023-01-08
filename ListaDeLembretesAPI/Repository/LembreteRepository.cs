using ListaDeLembretesAPI.Context;
using ListaDeLembretesAPI.Models;

namespace ListaDeLembretesAPI.Repository
{
    public class LembreteRepository : Repository<Lembrete>, ILembreteRepository
    {

        public LembreteRepository(AppDbContext contexto) : base(contexto) { }
        public IEnumerable<List<Lembrete>> GetGroupedByDate()
        {
            return Get().OrderBy(l => l.Data).GroupBy(l => l.Data).
                                Select(group => group.ToList()).ToList();
        }
    }
}