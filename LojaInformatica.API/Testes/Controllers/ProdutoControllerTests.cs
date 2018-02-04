using System.Collections.Generic;
using LojaInformatica.API.Controllers;
using LojaInformatica.API.Entidades;

namespace LojaInformatica.API.Testes.Controllers
{
    public class ProdutoControllerTests : ApiControllerTests<Produto>
    {
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
                    Preco = 3499.99m
                },
                new Produto()
                {
                    Id = 56,
                    Nome = "Monitor MultiPlasma - 56'",
                    Descricao = "Monitor MultiPlasma - 56 Polegadas. Qualidade Contestável.",
                    Preco = 2499.99m
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
                Preco = 2.49m
            };
        }

        protected override Produto ObterExemploEntidadeValidaParaInsercao()
        {
            return new Produto()
            {
                Id = 0,
                Nome = "Mouse Óptico Multiplasma",
                Descricao = "Mouse Óptico Multiplasma. Garantia de 15 minutos.",
                Preco = 3.49m
            };
        }
    }
}