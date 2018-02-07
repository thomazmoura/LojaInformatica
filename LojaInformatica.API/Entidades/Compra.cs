using System;
using System.Collections.Generic;
using System.Linq;

namespace LojaInformatica.API.Entidades
{
    public class Compra : Entidade
    {
        public DateTime DataDaCompra { get; set; }
        public decimal ValorTotalDaCompra => ItensDaCompra.Sum(item => item.PrecoUnitario * item.Quantidade);

        public virtual ICollection<ItemDaCompra> ItensDaCompra { get; set; }

        internal override bool PossuiTodosOsCamposObrigatorios => DataDaCompra != new DateTime()
            && ItensDaCompra.Any();
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
}