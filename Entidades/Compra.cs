using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaInformatica.Entidades
{
    public class Compra: Entidade
    {
        public DateTime DataDaCompra { get; set; }
        public decimal TotalDaCompra => ItensDaCompra.SomaDosItens();

        public virtual ICollection<ItemDaCompra> ItensDaCompra { get; set; }
    }

    public class ItemDaCompra
    {
        public int CompraId { get; set; }
        public int ProdutoId { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Compra Compra { get; set; }
    }

    public static class ItemDaCompraExtensions{
        public static decimal SomaDosItens(this IEnumerable<ItemDaCompra> itensDaCompra){
            return itensDaCompra.Sum(item => item.PrecoUnitario * item.Quantidade);
        }
    }
}