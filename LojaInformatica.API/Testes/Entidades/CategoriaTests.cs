using FluentAssertions;
using LojaInformatica.API.Entidades;
using Xunit;

namespace LojaInformatica.API.Testes.Entidades
{
    public class CategoriaTests : EntidadeTests<Categoria>
    {
        [Fact]
        public void Categoria_EquivaleA_Deve_retornar_false_para_categorias_com_nomes_diferentes()
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
        public void Categoria_EquivaleA_Deve_retornar_true_para_categorias_com_nomes_e_ids_iguais()
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