using System;
using System.Linq;

namespace LojaInformatica.Entidades
{
    public class Cliente: Entidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Guid ChaveDeAcesso { get; set; }
    }
}