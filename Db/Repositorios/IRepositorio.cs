using System.Linq;
using LojaInformatica.Models;

namespace LojaInformatica.Db.Repositorios
{
    public interface IRepositorio
    {
        IQueryable<Cliente> Clientes { get; }
        IQueryable<Compra> Compras { get; }
        IQueryable<Produto> Produtos { get; }

        void Acrescentar<Entidade>(Entidade entidade);
        void Atualizar<Entidade>(Entidade entidade);
        void Remover<Entidade>(Entidade entidade);
    }
}