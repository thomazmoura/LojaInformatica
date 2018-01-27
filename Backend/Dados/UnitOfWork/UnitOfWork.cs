using System;
using System.Collections.Generic;
using System.Linq;
using LojaInformatica.Dados.Contexto;

namespace LojaInformatica.Dados.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public Queue<Action> AcoesPrevias { get; private set; }

        public Queue<Action> AcoesPosteriores { get; private set; }

        private readonly LojaInformaticaContext _context;
        public UnitOfWork(LojaInformaticaContext context){
            _context = context;

            AcoesPrevias = new Queue<Action>();
            AcoesPosteriores = new Queue<Action>();
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