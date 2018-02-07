using FluentAssertions;
using LojaInformatica.API.Entidades;

namespace LojaInformatica.API.Testes.Entidades
{
    public abstract class EntidadeTests<TEntidade> where TEntidade : Entidade<TEntidade>, new()
    {
        public void Entidade_EquivaleA_Deve_retornar_false_quando_os_ids_forem_diferentes()
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