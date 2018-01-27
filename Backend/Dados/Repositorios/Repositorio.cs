using System.Linq;
using LojaInformatica.Dados.Contexto;
using LojaInformatica.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LojaInformatica.Dados.Repositorios
{
    public class Repositorio : IRepositorio
    {
        public IQueryable<Cliente> Clientes => _context.Clientes;

        public IQueryable<Compra> Compras => _context.Compras;

        public IQueryable<Produto> Produtos => _context.Produtos;

        private readonly LojaInformaticaContext _context;
        public Repositorio(LojaInformaticaContext context){
            _context = context;
        }

        public void Acrescentar<Entidade>(Entidade entidade) where Entidade: class
        {
            _context.Set<Entidade>().Add(entidade);
        }

        public void Atualizar<Entidade>(Entidade entidade) where Entidade: class
        {
            _context.Set<Entidade>().Attach(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
        }

        public void Remover<Entidade>(Entidade entidade) where Entidade: class
        {
            _context.Set<Entidade>().Remove(entidade);
        }
    }
}