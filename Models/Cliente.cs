using System;

namespace LojaInformatica.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Guid ChaveDeAcesso { get; set; }
    }
}