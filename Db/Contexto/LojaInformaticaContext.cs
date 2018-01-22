using LojaInformatica.Db.Configuracao;
using LojaInformatica.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaInformatica.Db.Contexto
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