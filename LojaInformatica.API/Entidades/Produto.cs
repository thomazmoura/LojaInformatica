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

        public Produto()
        {
            Imagens = new List<Imagem>();
        }

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

    public static class ProdutoExtensions
    {
        public static IQueryable<Produto> PorCategoria(this IQueryable<Produto> produtos, int categoriaId)
        {
            return produtos.Where(produto => produto.CategoriaId == categoriaId);
        }
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
            if (imagens.Count() == 0 && outrasImagens.Count() == 0)
                return true;

            var idsDasImagens = imagens.Select(imagem => imagem.Id).Distinct();
            var idsDasOutrasImagens = outrasImagens.Select(imagem => imagem.Id).Distinct();

            return idsDasImagens.Count() == idsDasOutrasImagens.Count() &&
                idsDasImagens.All(idDaImagem => idsDasOutrasImagens.Contains(idDaImagem));
        }
    }
}