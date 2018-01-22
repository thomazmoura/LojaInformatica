using System.Collections.Generic;
using System.Linq;

namespace LojaInformatica.Entidades
{
    public abstract class Entidade
    {
        public int Id { get; set; }
    }

    public static class EntidadeExtensions
    {
        public static IEnumerable<Entidade> EmMemoria(this IQueryable<Entidade> entidades)
        {
            return entidades.ToList();
        }

        public static Entidade PorId(this IQueryable<Entidade> entidades, int id)
        {
            return entidades.SingleOrDefault(entidade => entidade.Id == id);
        }
    }
}