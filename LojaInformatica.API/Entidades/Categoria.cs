using System.Collections.Generic;

namespace LojaInformatica.API.Entidades
{
    public class Categoria : Entidade<Categoria>
    {
        public Categoria()
        {
            Produtos = new List<Produto>();
        }

        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        internal override bool PossuiTodosOsCamposObrigatorios => !string.IsNullOrWhiteSpace(Nome);

        public override bool EquivaleA(Categoria outraEntidade)
        {
            return base.EquivaleA(outraEntidade) &&
                Nome == outraEntidade.Nome;
        }
    }
}