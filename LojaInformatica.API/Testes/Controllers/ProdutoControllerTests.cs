using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LojaInformatica.API.Controllers;
using LojaInformatica.API.Entidades;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace LojaInformatica.API.Testes.Controllers
{
    public class ProdutoControllerTests : ApiControllerTests<Produto>
    {
        private ProdutoController _produtoController => _controller as ProdutoController;
        protected override IEntidadeApi<Produto> ObterApiController()
        {
            return new ProdutoController(_ambienteDeTeste.Repositorio);
        }

        protected override Produto ObterExemploEntidadeInvalidaParaAtualizacao()
        {
            return new Produto()
            {
                Id = 0,
                Nome = null,
                Descricao = null
            };
        }

        protected override Produto ObterExemploEntidadeInvalidaParaInsercao()
        {
            return new Produto()
            {
                Id = 315,
                Nome = null,
                Descricao = null
            };
        }

        protected override IEnumerable<Produto> ObterExemploEntidades()
        {
            return new[]
            {
                new Produto()
                {
                    Id = 42,
                    Nome = "Monitor LA - 42'",
                    Descricao = "Monitor Life's Awesome - 42 Polegadas.",
                    Preco = 3499.99m,
                    Imagens = new []
                    {
                        new Imagem()
                        {
                            Id = 202,
                            ImagemPrincipal = true,
                            URL = "https://lojainformatica.com.null/imagens/produtos/monitor-la-42-1"
                        }
                    }
                },
                new Produto()
                {
                    Id = 56,
                    Nome = "Monitor MultiPlasma - 56'",
                    Descricao = "Monitor MultiPlasma - 56 Polegadas. Qualidade Contestável.",
                    Preco = 2499.99m,
                    Imagens = new []
                    {
                        new Imagem()
                        {
                            Id = 503,
                            ImagemPrincipal = true,
                            URL = "https://lojainformatica.com.null/imagens/produtos/monitor-multiplasma-56-1"
                        }
                    }
                }
            };
        }

        protected override Produto ObterExemploEntidadeValidaParaAtualizacao()
        {
            return new Produto()
            {
                Id = 1,
                Nome = "Mouse Óptico Multiplasma",
                Descricao = "Mouse Óptico Multiplasma. Garantia de 15 minutos.",
                Preco = 2.49m,
                Imagens = new[]
                {
                    new Imagem()
                    {
                        Id = 0,
                        URL = "https://lojainformatica.com.null/imagens/produtos/mouse-multiplasma-1"
                    },
                    new Imagem()
                    {
                        Id = 0,
                        ImagemPrincipal = true,
                        URL = "https://lojainformatica.com.null/imagens/produtos/mouse-multiplasma-2"
                    }
                }
            };
        }

        protected override Produto ObterExemploEntidadeValidaParaInsercao()
        {
            return new Produto()
            {
                Id = 0,
                Nome = "Mouse Óptico Multiplasma",
                Descricao = "Mouse Óptico Multiplasma. Garantia de 15 minutos.",
                Preco = 3.49m,
                Imagens = new[]
                {
                    new Imagem()
                    {
                        Id = 0,
                        ImagemPrincipal = true,
                        URL = "https://lojainformatica.com.null/imagens/produtos/mouse-multiplasma-1"
                    },
                    new Imagem()
                    {
                        Id = 0,
                        URL = "https://lojainformatica.com.null/imagens/produtos/mouse-multiplasma-2"
                    }
                }
            };
        }

        [Fact]
        public void Get_RetornaProdutoComImagens_QuandoOProdutoPossuiImagens()
        {
            var exemplosDeProdutos = ObterExemploEntidades();
            PersistirEntidades(exemplosDeProdutos);

            var resultado = _controller.Get() as OkObjectResult;
            var produtos = resultado.Value as IEnumerable<Produto>;
            var imagens = produtos.Select(produto => produto.Imagens);

            imagens.Should().NotBeEmpty();
        }


        [Fact]
        public void GetComCategoriaId_RetornaProdutosDaCategoria_QuandoACategoriaPossuiProdutos()
        {
            var produtosSemCategoriaQueNaoDevemSerRetornados = ObterExemploEntidades();
            PersistirEntidades(produtosSemCategoriaQueNaoDevemSerRetornados);
            var categoria = new Categoria()
            {
                Nome = "Periféricos"
            };
            var produtoDaCategoria = ObterExemploEntidadeValidaParaInsercao();
            categoria.Produtos.Add(produtoDaCategoria);
            PersistirEntidade(categoria);

            var resultado = _produtoController.GetComFiltros(categoria.Id) as OkObjectResult;
            var produtos = resultado.Value as IEnumerable<Produto>;
            var produtoRetornado = produtos.Single();

            produtoRetornado.EquivaleA(produtoDaCategoria).Should().BeTrue();
        }
    }
}