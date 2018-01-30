using LojaInformatica.API.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace LojaInformatica.API.Controllers
{
    public interface IEntidadeApi<TEntidade> where TEntidade : Entidade
    {
        IActionResult Get();
        IActionResult Get(int id);
        IActionResult Post([FromBody] TEntidade entidade);
        IActionResult Put([FromBody] TEntidade entidade);
        IActionResult Delete(int id);
    }
}