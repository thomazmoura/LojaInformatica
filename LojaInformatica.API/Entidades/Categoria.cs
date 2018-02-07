using System.Collections.Generic;

namespace LojaInformatica.API.Entidades
{
    public class Categoria : Entidade<Categoria>
    {
        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}