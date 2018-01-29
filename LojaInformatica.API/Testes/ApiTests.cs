using System.Collections.Generic;
using FluentAssertions;
using LojaInformatica.API.Controllers;
using LojaInformatica.API.Entidades;
using LojaInformatica.API.Testes.Configuracao;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace LojaInformatica.API.Testes
{
    public abstract class ApiTests<TEntidade> where TEntidade : Entidade
    {
        protected abstract IEntidadeApi<TEntidade> ObterApiController();

        protected readonly AmbienteDeTeste _ambienteDeTeste;
        protected readonly IEntidadeApi<TEntidade> _controller;
        protected ApiTests()
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
    }
}