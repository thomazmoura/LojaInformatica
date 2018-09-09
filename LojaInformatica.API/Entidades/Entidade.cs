using System;
using System.Collections.Generic;
using System.Linq;
using LojaInformatica.API.Objetos;

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
        public static IEnumerable<TEntidade> EmMemoria<TEntidade>(this IQueryable<TEntidade> entidades) where TEntidade : Entidade
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

        public static TEntidade PorId<TEntidade>(this IQueryable<TEntidade> entidades, int id) where TEntidade : Entidade
        {
            return entidades.SingleOrDefault(entidade => entidade.Id == id);
        }

        public static IOrderedQueryable<TEntidade> OrdernarPor<TEntidade, TKey>(this IQueryable<TEntidade> entidades, Func<TEntidade, TKey> ordernarPor, bool ascendente = true) where TEntidade : Entidade
        {
            return ascendente ?
                entidades.OrderBy(e => ordernarPor) :
                entidades.OrderByDescending(e => ordernarPor);
        }

        public static IQueryable<TEntidade> Paginar<TEntidade>(this IOrderedQueryable<TEntidade> entidades, Paginacao paginacao) where TEntidade : Entidade
        {
            if (paginacao == null || paginacao.Pagina == 0 || paginacao.Tamanho == 0)
                return entidades;

            return entidades
                .Skip(paginacao.ElementosParaPular)
                .Take(paginacao.Tamanho);
        }
    }
}
