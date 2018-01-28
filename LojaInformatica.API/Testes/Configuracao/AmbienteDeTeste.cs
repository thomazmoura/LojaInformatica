using System;
using LojaInformatica.API.Dados;
using Microsoft.EntityFrameworkCore;

namespace LojaInformatica.API.Testes.Configuracao
{
    public class AmbienteDeTeste
    {
        public ContextoLojaInformatica Contexto { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
        public IRepositorio Repositorio { get; set; }

        public static AmbienteDeTeste NovoAmbiente()
        {
            var options = new DbContextOptionsBuilder<ContextoLojaInformatica>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var contexto = new ContextoLojaInformatica(options);

            return new AmbienteDeTeste()
            {
                Contexto = contexto,
                UnitOfWork = new UnitOfWork(contexto),
                Repositorio = new RepositorioPostgresql(contexto)
            };
        }
    }
}