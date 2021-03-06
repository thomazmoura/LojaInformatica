using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LojaInformatica.API.Controllers;
using LojaInformatica.API.Entidades;
using LojaInformatica.API.Objetos;
using LojaInformatica.API.Testes.Configuracao;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace LojaInformatica.API.Testes.Controllers
{
    public class ClienteControllerTests : ApiControllerTests<Cliente>
    {
        private ClienteController _clienteController => _controller as ClienteController;
        public ClienteControllerTests() { }

        protected override IEntidadeApi<Cliente> ObterApiController()
        {
            return new ClienteController(_ambienteDeTeste.Repositorio);
        }

        protected override IEnumerable<Cliente> ObterExemploEntidades()
        {
            return new []
            {
                new Cliente
                {
                    Id = 200,
                        Nome = "Um Dois Três da Silva Quatro",
                        Email = "1234@email.com",
                        ChaveDeAcesso = new Guid("9690d1ba-f047-4974-a58b-9fe32e6a36d1")
                },
                new Cliente
                {
                    Id = 201,
                        Nome = "Fulano Cicrano Beltrano",
                        Email = "johndoe@email.com",
                        ChaveDeAcesso = new Guid("572db7a9-5a1d-4bed-a52e-af67ac033787")
                }
            };
        }

        protected override Cliente ObterExemploEntidadeInvalidaParaInsercao() => new Cliente()
        {
            Nome = null,
            Email = null,
            Id = 400
        };
        protected override Cliente ObterExemploEntidadeValidaParaInsercao() => new Cliente()
        {
            Nome = "Teste",
            Email = "teste@email.com",
            Id = 0
        };
        protected override Cliente ObterExemploEntidadeInvalidaParaAtualizacao() => new Cliente()
        {
            Nome = null,
            Email = null,
            Id = 0
        };
        protected override Cliente ObterExemploEntidadeValidaParaAtualizacao() => new Cliente()
        {
            Nome = "Teste",
            Email = "teste@email.com",
            Id = 204
        };

        [Fact]
        public void GetComNome_RetornaClientesFiltradosPorNome_QuandoExistiremClientesComONome()
        {
            var filtroDeNome = new PaginacaoDeCliente()
            {
                FiltroPorNome = "beltrano"
            };
            var entidades = ObterExemploEntidades();
            PersistirEntidades(entidades);
            var clientesFiltrados = entidades.AsQueryable()
                .PorNome(filtroDeNome.FiltroPorNome);

            var resultado = _clienteController.Get(filtroDeNome) as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<Cliente>;

            CompararEntidades(clientes, clientesFiltrados).Should().BeTrue();
        }

        [Fact]
        public void GetComNome_RetornaListaVazia_QuandoNãoExistiremClientesComONome()
        {
            var filtroDeNome = new PaginacaoDeCliente()
            {
                FiltroPorNome = "inexistente"
            };
            var entidades = ObterExemploEntidades();
            PersistirEntidades(entidades);
            var clientesFiltrados = entidades.AsQueryable()
                .PorNome(filtroDeNome.FiltroPorNome);

            var resultado = _clienteController.Get(filtroDeNome) as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<Cliente>;

            clientes.Should().NotBeNull();
            clientes.Should().BeEmpty();
        }

        [Fact]
        public void GetComOrdenacao_RetornaListaOrdenada_QuandoAOrdenacaoPorNomeForInformada()
        {
            var ordenacaoPorNome = new PaginacaoDeCliente()
            {
                ParametroParaOdernacao = "nome",
                Ascendente = true
            };
            var entidades = new []
            {
                new Cliente()
                {
                    Nome = "Fulano Segundo",
                    Email = "fulano.segundo@email.com"
                },
                new Cliente()
                {
                    Nome = "Cicrano Primeiro",
                    Email = "cicrano.primeiro@email.com"
                }
            };
            PersistirEntidades(entidades);
            var clientesOrdenados = entidades
                .OrderBy(cliente => cliente.Nome);

            var resultado = _clienteController.Get(ordenacaoPorNome) as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<Cliente>;

            CompararEntidades(clientes, clientesOrdenados).Should().BeTrue();
        }

        [Fact]
        public void GetComOrdenacao_RetornaListaOrdenada_QuandoAOrdenacaoPorEmailForInformada()
        {
            var ordenacaoPorEmail = new PaginacaoDeCliente()
            {
                ParametroParaOdernacao = "email",
                Ascendente = true
            };
            var entidades = new []
            {
                new Cliente()
                {
                    Nome = "Fulano Segundo",
                    Email = "fulano.segundo@email.com"
                },
                new Cliente()
                {
                    Nome = "Cicrano Primeiro",
                    Email = "cicrano.primeiro@email.com"
                }
            };
            PersistirEntidades(entidades);
            var clientesOrdenados = entidades
                .OrderByDescending(cliente => cliente.Email);

            var resultado = _clienteController.Get(ordenacaoPorEmail) as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<Cliente>;

            CompararEntidades(clientes, clientesOrdenados).Should().BeTrue();
        }

        [Fact]
        public void GetComOrdenacao_RetornaListaPaginada_QuandoAPaginacaoForInformada()
        {
            var ordenacaoPorEmail = new PaginacaoDeCliente()
            {
                ParametroParaOdernacao = "nome",
                Pagina = 1,
                Tamanho = 1,
                Ascendente = true
            };
            var entidades = new []
            {
                new Cliente()
                {
                    Nome = "Fulano Segundo",
                    Email = "fulano.segundo@email.com"
                },
                new Cliente()
                {
                    Nome = "Cicrano Primeiro",
                    Email = "cicrano.primeiro@email.com"
                }
            };
            PersistirEntidades(entidades);
            var clientesOrdenados = entidades
                .OrderByDescending(cliente => cliente.Email)
                .Take(1);

            var resultado = _clienteController.Get(ordenacaoPorEmail) as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<Cliente>;

            CompararEntidades(clientes, clientesOrdenados).Should().BeTrue();
        }
    }
}
