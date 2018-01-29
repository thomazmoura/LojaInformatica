using System.Linq;
using LojaInformatica.API.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LojaInformatica.API.Filters
{
    public class IQueryableIteratorFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var resultado = context.Result as ObjectResult;

            if (resultado == null)
                return;

            var entidades = resultado.Value as IQueryable<Entidade>;

            if (entidades == null)
                return;

            (context.Result as ObjectResult).Value = entidades.EmMemoria();
        }

        public void OnActionExecuting(ActionExecutingContext context) { }
    }
}