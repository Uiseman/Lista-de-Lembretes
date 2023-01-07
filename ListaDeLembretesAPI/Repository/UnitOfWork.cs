using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaDeLembretesAPI.Context;

namespace ListaDeLembretesAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private LembreteRepository _lembreteRepo;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;

        }

        public ILembreteRepository LembreteRepository
        {
            get
            {
                return _lembreteRepo = _lembreteRepo ?? new LembreteRepository(_context);
            }
        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}