using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LojaInformatica.API.Controllers;
using LojaInformatica.API.Entidades;
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
            return new[]{
                new Cliente{
                    Id = 200,
                    Nome = "Um Dois Três da Silva Quatro",
                    Email = "1234@email.com",
                    ChaveDeAcesso = new Guid("9690d1ba-f047-4974-a58b-9fe32e6a36d1")
                },
                new Cliente{
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
            var filtroDeNome = "beltrano";
            var entidades = ObterExemploEntidades();
            PersistirEntidades(entidades);
            var clientesFiltrados = entidades.AsQueryable()
                .PorNome(filtroDeNome);

            var resultado = _clienteController.Get(filtroDeNome) as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<Cliente>;

            CompararEntidades(clientes, clientesFiltrados).Should().BeTrue();
        }

        [Fact]
        public void GetComNome_RetornaListaVazia_QuandoNãoExistiremClientesComONome()
        {
            var filtroDeNome = "inexistente";
            var entidades = ObterExemploEntidades();
            PersistirEntidades(entidades);
            var clientesFiltrados = entidades.AsQueryable()
                .PorNome(filtroDeNome);

            var resultado = _clienteController.Get(filtroDeNome) as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<Cliente>;

            clientes.Should().NotBeNull();
            clientes.Should().BeEmpty();
        }
    }
}