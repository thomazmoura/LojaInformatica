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
    public abstract class ApiControllerTests<TEntidade> where TEntidade : Entidade
    {
        protected abstract IEntidadeApi<TEntidade> ObterApiController();
        protected abstract IEnumerable<TEntidade> ObterExemploEntidades();
        protected abstract void PersistirEntidades(IEnumerable<TEntidade> entidades);

        protected readonly AmbienteDeTeste _ambienteDeTeste;
        protected readonly IEntidadeApi<TEntidade> _controller;
        protected ApiControllerTests()
        {
            _ambienteDeTeste = AmbienteDeTeste.NovoAmbiente();
            _controller = ObterApiController();
        }

        [Fact]
        public void Api_Get_Deve_retornar_uma_lista_vazia_quando_não_houver_dados_no_banco()
        {
            var resultado = _controller.Get() as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<TEntidade>;

            clientes.Should().BeEmpty();
        }

        [Fact]
        public void Clientes_Get_Deve_retornar_a_lista_de_clientes_registrada_quando_houverem_clientes()
        {
            var entidades = ObterExemploEntidades();
            PersistirEntidades(entidades);

            var resultado = _controller.Get() as OkObjectResult;
            var clientes = resultado.Value as IEnumerable<Cliente>;

            clientes.Should().BeEquivalentTo(entidades);
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
            var entidades = ObterExemploEntidades();
            PersistirEntidades(entidades);
            var clienteDeExemplo = entidades.First();

            var resultado = _controller.Get(clienteDeExemplo.Id) as OkObjectResult;
            var cliente = resultado.Value as Cliente;

            cliente.ShouldBeEquivalentTo(clienteDeExemplo);
        }
    }
}