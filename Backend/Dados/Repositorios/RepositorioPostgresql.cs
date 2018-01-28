using System;
using System.Linq;
using LojaInformatica.Dados.Contexto;
using LojaInformatica.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LojaInformatica.Dados.Repositorios
{
    public class RepositorioPostgresql : IRepositorio
    {
        public IQueryable<Cliente> Clientes => _context.Clientes;

        public IQueryable<Compra> Compras => _context.Compras;

        public IQueryable<Produto> Produtos => _context.Produtos;

        private readonly LojaInformaticaContext _context;
        public RepositorioPostgresql(LojaInformaticaContext context){
            _context = context;
        }

        public void Acrescentar<T>(T entidade) where T: class
        {
            _context.Set<T>().Add(entidade);
        }

        public void Atualizar<T>(T entidade) where T: class
        {
            _context.Set<T>().Attach(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
        }

        public void Remover<T>(T entidade) where T: class
        {
            _context.Set<T>().Remove(entidade);
        }
    }
}