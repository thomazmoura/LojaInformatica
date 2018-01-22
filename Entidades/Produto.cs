using System.Collections.Generic;

namespace LojaInformatica.Entidades
{
    public class Produto: Entidade
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        
        public virtual Imagem ImagemPrincipal { get; set; }
        public virtual ICollection<Imagem> Imagens { get; set; }
        public virtual ICollection<ItemDaCompra> ItemComprados { get; set; }
    }
}