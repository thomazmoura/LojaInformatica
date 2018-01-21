using System.Linq;
using LojaInformatica.Models;

namespace LojaInformatica.Db.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public IQueryable<Cliente> Clientes => throw new System.NotImplementedException();

        public IQueryable<Compra> Compras => throw new System.NotImplementedException();

        public IQueryable<Produto> Produtos => throw new System.NotImplementedException();

        public void Acrescentar<Entidade>(Entidade entidade)
        {
            throw new System.NotImplementedException();
        }

        public void Atualizar<Entidade>(Entidade entidade)
        {
            throw new System.NotImplementedException();
        }

        public void Remover<Entidade>(Entidade entidade)
        {
            throw new System.NotImplementedException();
        }
    }
}