using System;
using System.Linq;

namespace LojaInformatica.API.Entidades
{
    public class Cliente : Entidade<Cliente>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Guid ChaveDeAcesso { get; set; }

        internal override bool PossuiTodosOsCamposObrigatorios => !string.IsNullOrWhiteSpace(Nome)
                && !string.IsNullOrWhiteSpace(Email);

        public override bool EquivaleA(Cliente outroCliente)
        {
            return base.EquivaleA(outroCliente)
                && Nome == outroCliente.Nome
                && Email == outroCliente.Email;
        }
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