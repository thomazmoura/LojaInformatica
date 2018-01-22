using LojaInformatica.Db.UnitOfWork;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LojaInformatica.Filters
{
    public class UnitOfWorkFilter : IActionFilter
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitOfWorkFilter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception == null)
                _unitOfWork.SalvarAlteracoes();
        }

        public void OnActionExecuting(ActionExecutingContext context){}
    }
}