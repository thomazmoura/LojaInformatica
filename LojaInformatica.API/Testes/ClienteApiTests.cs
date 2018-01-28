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
    public class ClienteApiTests
    {
        private readonly AmbienteDeTeste _ambienteDeTeste;
        private readonly ClienteController _controller;

        public ClienteApiTests()
        {
            _ambienteDeTeste = AmbienteDeTeste.NovoAmbiente();
            _controller = new ClienteController(_ambienteDeTeste.Repositorio);
        }

        [Fact]
        public void Clientes_Get_Deve_retornar_uma_lista_vazia_quando_não_houver_nenhum_cliente_registrado()
        {
            var resultado = _controller.Get() as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<Cliente>;

            clientes.Should().BeEmpty();
        }

        [Fact]
        public void Clientes_Get_Deve_retornar_a_lista_de_clientes_registrada_quando_houverem_clientes()
        {
            PersistirClientes(ExemplosDeClientes);

            var resultado = _controller.Get() as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<Cliente>;

            clientes.Should().BeEquivalentTo(ExemplosDeClientes);
            clientes.Count().Should().Be(2);
        }

        [Fact]
        public void Clientes_Get_Com_nome_Deve_retornar_a_lista_de_clientes_filtrada_por_nome()
        {
            var filtroDeNome = "beltrano";
            PersistirClientes(ExemplosDeClientes);
            var clientesFiltrados = ExemplosDeClientes.AsQueryable()
                .PorNome(filtroDeNome);

            var resultado = _controller.Get(filtroDeNome) as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<Cliente>;

            clientes.Should().BeEquivalentTo(clientesFiltrados);
        }

        [Fact]
        public void Clientes_Get_Id_Deve_retornar_NotFound_quando_o_cliente_não_existir()
        {
            var idAusenteNoBanco = 404;

            var resultado = _controller.Get(idAusenteNoBanco);

            resultado.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void Clientes_Get_Id_Deve_retornar_o_cliente_específico_se_existir()
        {
            PersistirClientes(ExemplosDeClientes);
            var clienteDeExemplo = ExemplosDeClientes.First();

            var resultado = _controller.Get(clienteDeExemplo.Id) as OkObjectResult;
            var cliente = resultado.Value as Cliente;

            cliente.ShouldBeEquivalentTo(clienteDeExemplo);
        }

        public void PersistirClientes(IEnumerable<Cliente> clientes)
        {
            _ambienteDeTeste.Contexto.Clientes.AddRange(clientes);
            _ambienteDeTeste.Contexto.SaveChanges();
        }

        public IEnumerable<Cliente> ExemplosDeClientes = new[]{
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
}