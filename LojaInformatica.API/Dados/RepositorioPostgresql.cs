using System;
using System.Linq;
using LojaInformatica.API.Dados;
using LojaInformatica.API.Entidades;
using Microsoft.EntityFrameworkCore;

namespace LojaInformatica.API.Dados
{
    public class RepositorioPostgresql : IRepositorio
    {
        public IQueryable<Cliente> Clientes => _context.Clientes;

        public IQueryable<Compra> Compras => _context.Compras;

        public IQueryable<Produto> Produtos => _context.Produtos.Include(produto => produto.Imagens);

        public IQueryable<Categoria> Categorias => _context.Categorias;


        private readonly ContextoLojaInformatica _context;
        public RepositorioPostgresql(ContextoLojaInformatica context)
        {
            _context = context;
        }

        public void Acrescentar<T>(T entidade) where T : Entidade
        {
            _context.Set<T>().Add(entidade);
        }

        public void Atualizar<T>(T entidade) where T : Entidade
        {
            _context.Set<T>().Update(entidade);
            _context.Entry(entidade).State = EntityState.Modified;
        }

        public void Remover<T>(T entidade) where T : Entidade
        {
            _context.Set<T>().Remove(entidade);
        }

        public void Remover<T>(int id) where T : Entidade, new()
        {
            var entidade = new T()
            {
                Id = id
            };
            _context.Set<T>().Attach(entidade);
            _context.Set<T>().Remove(entidade);
        }
    }
}