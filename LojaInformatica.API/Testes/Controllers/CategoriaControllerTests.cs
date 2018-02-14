using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LojaInformatica.API.Controllers;
using LojaInformatica.API.Entidades;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace LojaInformatica.API.Testes.Controllers
{
    public class CategoriaControllerTests : ApiControllerTests<Categoria>
    {
        private CategoriaController _categoriaController => _controller as CategoriaController;

        protected override IEntidadeApi<Categoria> ObterApiController()
        {
            return new CategoriaController(_ambienteDeTeste.Repositorio);
        }

        protected override Categoria ObterExemploEntidadeInvalidaParaAtualizacao()
        {
            return new Categoria()
            {
                Id = 0,
                Nome = null
            };
        }

        protected override Categoria ObterExemploEntidadeInvalidaParaInsercao()
        {
            return new Categoria()
            {
                Id = 400,
                Nome = null
            };
        }

        protected override IEnumerable<Categoria> ObterExemploEntidades()
        {
            return new[]
            {
                new Categoria()
                {
                    Id = 42,
                    Nome = "Monitor"
                },
                new Categoria()
                {
                    Id = 21,
                    Nome = "Gabinete"
                }
            };
        }

        protected override Categoria ObterExemploEntidadeValidaParaAtualizacao()
        {
            return new Categoria()
            {
                Id = 42,
                Nome = "Monitor"
            };
        }

        protected override Categoria ObterExemploEntidadeValidaParaInsercao()
        {
            return new Categoria()
            {
                Id = 0,
                Nome = "Monitor"
            };
        }

        [Fact]
        public void GetProdutos_RetornaProdutosDaCategoria_QuandoACategoriaPossuiProdutos()
        {
            var categoria = ObterExemploEntidadeValidaParaInsercao();
            var produto = new Produto()
            {
                Nome = "Monitor Xing Ling",
                Preco = 99.99m,
                Descricao = "Monitor Xing Ling fabricado na China. Imita concorrente"
            };
            categoria.Produtos.Add(produto);
            PersistirEntidade(categoria);

            var resultado = _categoriaController.GetProdutos(categoria.Id) as OkObjectResult;
            var produtos = resultado.Value as IEnumerable<Produto>;
            var produtoRetornado = produtos.Single();

            produtoRetornado.EquivaleA(produto).Should().BeTrue();
        }
    }
}