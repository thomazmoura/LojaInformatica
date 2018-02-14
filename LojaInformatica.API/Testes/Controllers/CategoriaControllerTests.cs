using System.Collections.Generic;
using LojaInformatica.API.Controllers;
using LojaInformatica.API.Entidades;

namespace LojaInformatica.API.Testes.Controllers
{
    public class CategoriaControllerTests : ApiControllerTests<Categoria>
    {
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
    }
}