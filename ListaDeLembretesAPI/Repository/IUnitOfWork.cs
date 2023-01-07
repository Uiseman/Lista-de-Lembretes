using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaDeLembretesAPI.Repository
{
    public interface IUnitOfWork
    {
        ILembreteRepository LembreteRepository { get; }

        void Commit();
    }
}