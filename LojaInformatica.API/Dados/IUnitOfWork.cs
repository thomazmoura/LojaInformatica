using System;
using System.Collections.Generic;

namespace LojaInformatica.API.Dados
{
    public interface IUnitOfWork
    {
        Queue<Action> AcoesPrevias { get; }
        Queue<Action> AcoesPosteriores { get; }
        void SalvarAlteracoes();
    }
}