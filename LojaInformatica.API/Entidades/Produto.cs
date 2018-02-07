using System.Collections.Generic;
using System.Linq;

namespace LojaInformatica.API.Entidades
{
    public class Produto : Entidade<Produto>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public int? CategoriaId { get; set; }

        public virtual ICollection<Imagem> Imagens { get; set; }
        public virtual ICollection<ItemDaCompra> ItemComprados { get; set; }
        public virtual Categoria Categoria { get; set; }

        public override bool EquivaleA(Produto outroProduto)
        {
            return base.EquivaleA(outroProduto)
                && Nome == outroProduto.Nome
                && Descricao == outroProduto.Descricao
                && Preco == outroProduto.Preco
                && Imagens.EquivalemA(outroProduto.Imagens);
        }

        internal override bool PossuiTodosOsCamposObrigatorios => Preco > 0
                 && !string.IsNullOrWhiteSpace(Nome)
                 && !string.IsNullOrWhiteSpace(Descricao)
                 && Imagens != null && Imagens.Any();
    }

    public class Imagem : Entidade
    {
        public string URL { get; set; }
        public bool ImagemPrincipal { get; set; }

        public int ProdutoId { get; set; }

        internal override bool PossuiTodosOsCamposObrigatorios => !string.IsNullOrWhiteSpace(URL);
    }

    public static class ImagemExtensions
    {
        public static bool EquivalemA(this IEnumerable<Imagem> imagens, IEnumerable<Imagem> outrasImagens)
        {
            var idsDasImagens = imagens.Select(imagem => imagem.Id).Distinct();
            var idsDasOutrasImagens = outrasImagens.Select(imagem => imagem.Id).Distinct();

            return idsDasImagens.Count() == idsDasOutrasImagens.Count() &&
                idsDasImagens.All(idDaImagem => idsDasOutrasImagens.Contains(idDaImagem));
        }
    }
}