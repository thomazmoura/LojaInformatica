using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using LojaInformatica.API.Controllers;
using LojaInformatica.API.Entidades;
using LojaInformatica.API.Testes.Configuracao;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace LojaInformatica.API.Testes
{
    public class ClienteApiTests : ApiTests<Cliente>
    {
        private ClienteController _clienteController => _controller as ClienteController;
        public ClienteApiTests() { }

        protected override IEntidadeApi<Cliente> ObterApiController()
        {
            return new ClienteController(_ambienteDeTeste.Repositorio);
        }

        private readonly IEnumerable<Cliente> _clientes;
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

        protected override void PersistirEntidades(IEnumerable<Cliente> clientes)
        {
            _ambienteDeTeste.Contexto.Clientes.AddRange(clientes);
            _ambienteDeTeste.Contexto.SaveChanges();
        }

        [Fact]
        public void Clientes_Get_Com_nome_Deve_retornar_a_lista_de_clientes_filtrada_por_nome()
        {
            var filtroDeNome = "beltrano";
            var entidades = ObterExemploEntidades();
            PersistirEntidades(entidades);
            var clientesFiltrados = entidades.AsQueryable()
                .PorNome(filtroDeNome);

            var resultado = _clienteController.Get(filtroDeNome) as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<Cliente>;

            clientes.Should().BeEquivalentTo(clientesFiltrados);
        }
    }
}