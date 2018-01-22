using System;
using System.Collections.Generic;

namespace LojaInformatica.Db.UnitOfWork
{
    public interface IUnitOfWork
    {
        Queue<Action> AcoesPrevias { get; }
        Queue<Action> AcoesPosteriores { get; }
        void SalvarAlteracoes();
    }
}