using FluentAssertions;
using LojaInformatica.API.Entidades;
using Xunit;

namespace LojaInformatica.API.Testes.Entidades
{
    public class CategoriaTests : EntidadeTests<Categoria>
    {
        [Fact]
        public void CategoriaEquivaleA_RetornaFalse_QuandoCategoriasTêmNomesDiferentes()
        {
            var categoriaComparada = new Categoria()
            {
                Id = 1,
                Nome = "Monitores"
            };

            var categoriaReferencia = new Categoria()
            {
                Id = 1,
                Nome = "Gabinetes"
            };

            var categoriasSaoEquivalentes = categoriaComparada.EquivaleA(categoriaReferencia);

            categoriasSaoEquivalentes.Should().BeFalse();
        }

        [Fact]
        public void CategoriaEquivaleA_RetornaTrue_QuandoCategoriasTêmNomeEIdIguais()
        {
            var categoriaComparada = new Categoria()
            {
                Id = 1,
                Nome = "Monitores"
            };

            var categoriaReferencia = new Categoria()
            {
                Id = 1,
                Nome = "Monitores"
            };

            var categoriasSaoEquivalentes = categoriaComparada.EquivaleA(categoriaReferencia);

            categoriasSaoEquivalentes.Should().BeTrue();
        }
    }
}