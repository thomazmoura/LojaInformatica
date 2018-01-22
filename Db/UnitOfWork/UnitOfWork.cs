using System;
using System.Collections.Generic;
using System.Linq;
using LojaInformatica.Db.Contexto;

namespace LojaInformatica.Db.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public Queue<Action> AcoesPrevias { get; private set; }

        public Queue<Action> AcoesPosteriores { get; private set; }

        private readonly LojaInformaticaContext _context;
        public UnitOfWork(LojaInformaticaContext context){
            _context = context;
        }

        public void SalvarAlteracoes()
        {
            while(AcoesPrevias.Any())
                AcoesPrevias.Dequeue().Invoke();

            _context.SaveChanges();

            while(AcoesPosteriores.Any())
                AcoesPosteriores.Dequeue().Invoke();
        }
    }
}