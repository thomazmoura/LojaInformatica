using System;
using System.Linq;

namespace LojaInformatica.Entidades
{
    public class Cliente: Entidade
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Guid ChaveDeAcesso { get; set; }

        public bool EstaValidoParaAtualizacao =>  Id != 0 && !string.IsNullOrWhiteSpace(Nome);
    }

    public static class ClienteExtensions 
    {
        public static IQueryable<Cliente> PorNome(this IQueryable<Cliente> clientes, string nome)
        {
            var nomeMinusculo = nome.ToLower();
            return clientes.Where(cliente => cliente.Nome.ToLower().Contains(nomeMinusculo));
        }

        public static IQueryable<Cliente> PorNomeExato(this IQueryable<Cliente> clientes, string nomeExato)
        {
            return clientes.Where(cliente => cliente.Nome == nomeExato);
        }
    }
}