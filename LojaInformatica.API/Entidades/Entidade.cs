using System.Collections.Generic;
using System.Linq;

namespace LojaInformatica.API.Entidades
{
    public abstract class Entidade
    {
        public int Id { get; set; }
        internal virtual bool EstaValidoParaInsercao => Id == 0 && PossuiTodosOsCamposObrigatorios;
        internal virtual bool EstaValidoParaAtualizacao => Id != 0 && PossuiTodosOsCamposObrigatorios;
        internal abstract bool PossuiTodosOsCamposObrigatorios { get; }
    }

    public abstract class Entidade<TEntidade> : Entidade where TEntidade : Entidade
    {
        public virtual bool EquivaleA(TEntidade outraEntidade)
        {
            return Id == outraEntidade.Id;
        }
    }

    public static class EntidadeExtensions
    {
        public static IEnumerable<Entidade> EmMemoria(this IQueryable<Entidade> entidades)
        {
            return entidades.ToList();
        }

        public static bool PossuiAlgumValor(this IQueryable<Entidade> entidades)
        {
            return entidades.Any();
        }

        public static bool ConstaNoBanco(this IQueryable<Entidade> entidades, int id)
        {
            return entidades.Any(entidade => entidade.Id == id);
        }

        public static Entidade PorId(this IQueryable<Entidade> entidades, int id)
        {
            return entidades.SingleOrDefault(entidade => entidade.Id == id);
        }
    }
}