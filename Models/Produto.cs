using System.Collections.Generic;

namespace LojaInformatica.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Imagem ImagemPrincipal { get; set; }
        public virtual ICollection<Imagem> Imagens { get; set; }
        public decimal Preco { get; set; }
    }
}