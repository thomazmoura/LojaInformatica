using System;
using System.Linq;
using LojaInformatica.Entidades;

namespace LojaInformatica.Dados.Repositorios
{
    public interface IRepositorio
    {
        IQueryable<Cliente> Clientes { get; }
        IQueryable<Compra> Compras { get; }
        IQueryable<Produto> Produtos { get; }

        void Acrescentar<Entidade>(Entidade entidade) where Entidade: class;
        void Atualizar<Entidade>(Entidade entidade) where Entidade: class;
        void Remover<Entidade>(Entidade entidade) where Entidade: class;

        Func<IQueryable<Cliente>, string, IQueryable<Cliente>> compararString { get; }
    }
}