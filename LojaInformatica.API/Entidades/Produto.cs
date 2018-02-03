using System.Collections.Generic;

namespace LojaInformatica.API.Entidades
{
    public class Produto : Entidade<Produto>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public virtual Imagem ImagemPrincipal { get; set; }
        public virtual ICollection<Imagem> Imagens { get; set; }
        public virtual ICollection<ItemDaCompra> ItemComprados { get; set; }

        public override bool EstaValidoParaInsercao => base.EstaValidoParaInsercao
                 && Preco > 0
                 && !string.IsNullOrWhiteSpace(Nome);

        public override bool EstaValidoParaAtualizacao => base.EstaValidoParaAtualizacao
                && Preco > 0
                && !string.IsNullOrWhiteSpace(Nome);

        public override bool EquivaleA(Produto outroProduto)
        {
            return base.EquivaleA(outroProduto)
                && outroProduto.Nome == Nome
                && outroProduto.Descricao == Descricao
                && outroProduto.Preco == Preco;
        }
    }
}