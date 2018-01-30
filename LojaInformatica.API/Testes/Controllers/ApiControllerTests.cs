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
            var entidades = resultado.Value as IEnumerable<TEntidade>;

            entidades.Should().BeEmpty();
        }

        [Fact]
        public void Api_Get_Deve_retornar_a_lista_de_entidades_registradas_quando_houver_entidades_persistidas()
        {
            var entidadesPersistidas = ObterExemploEntidades();
            PersistirEntidades(entidadesPersistidas);

            var resultado = _controller.Get() as OkObjectResult;
            var entidades = resultado.Value as IEnumerable<TEntidade>;

            entidades.Should().BeEquivalentTo(entidadesPersistidas);
        }

        [Fact]
        public void Api_Get_Id_Deve_retornar_NotFound_quando_a_entidade_não_existir()
        {
            var idAusenteNoBanco = 404;

            var resultado = _controller.Get(idAusenteNoBanco);

            resultado.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void Api_Get_Id_Deve_retornar_a_entidade_específica_se_a_mesma_existir()
        {
            var entidades = ObterExemploEntidades();
            PersistirEntidades(entidades);
            var entidadeDeExemplo = entidades.First();

            var resultado = _controller.Get(entidadeDeExemplo.Id) as OkObjectResult;
            var entidade = resultado.Value as TEntidade;

            entidade.ShouldBeEquivalentTo(entidadeDeExemplo);
        }
    }
}