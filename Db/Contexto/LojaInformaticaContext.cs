using LojaInformatica.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaInformatica.Db.Contexto
{
    public class LojaInformaticaContext: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}