using FluentAssertions;
using LojaInformatica.API.Entidades;

namespace LojaInformatica.API.Testes.Entidades
{
    public abstract class EntidadeTests<TEntidade> where TEntidade : Entidade<TEntidade>, new()
    {
        public void EntidadeEquivaleA_RetornaFalse_QuandoIdsSãoDiferentes()
        {
            var entidadeComparada = new TEntidade()
            {
                Id = 1
            };
            var entidadeReferencia = new TEntidade()
            {
                Id = 2
            };

            var entidadesSaoEquivalentes = entidadeComparada.EquivaleA(entidadeReferencia);

            entidadesSaoEquivalentes.Should().BeFalse();
        }
    }
}