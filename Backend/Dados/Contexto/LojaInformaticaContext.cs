using LojaInformatica.Dados.Configuracao;
using LojaInformatica.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LojaInformatica.Dados.Contexto
{
    public class LojaInformaticaContext: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public LojaInformaticaContext(DbContextOptions<LojaInformaticaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguracao());
            modelBuilder.ApplyConfiguration(new ItemDaCompraConfiguracao());
        }
    }
}