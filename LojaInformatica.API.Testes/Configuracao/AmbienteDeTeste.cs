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

        public static AmbienteDeTeste NovoAmbiente(string chaveDoBanco = null)
        {
            chaveDoBanco = chaveDoBanco ?? Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<ContextoLojaInformatica>()
                .UseInMemoryDatabase(chaveDoBanco)
                .EnableSensitiveDataLogging()
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