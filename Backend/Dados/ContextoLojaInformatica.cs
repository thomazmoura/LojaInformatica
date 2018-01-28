using LojaInformatica.Dados.Configuracao;
using LojaInformatica.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LojaInformatica.Dados
{
    public class LojaInformaticaContexto: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public LojaInformaticaContexto(DbContextOptions<LojaInformaticaContexto> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteConfiguracao());
            modelBuilder.ApplyConfiguration(new ItemDaCompraConfiguracao());
        }
    }
}