using System;
using System.Linq;
using LojaInformatica.API.Entidades;

namespace LojaInformatica.API.Dados
{
    public interface IRepositorio
    {
        IQueryable<Cliente> Clientes { get; }
        IQueryable<Compra> Compras { get; }
        IQueryable<Produto> Produtos { get; }
        IQueryable<Categoria> Categorias { get; }

        void Acrescentar<TEntidade>(TEntidade entidade) where TEntidade : Entidade;
        void Atualizar<TEntidade>(TEntidade entidade) where TEntidade : Entidade;
        void Remover<TEntidade>(TEntidade entidade) where TEntidade : Entidade;
        void Remover<TEntidade>(int id) where TEntidade : Entidade, new();
    }
}