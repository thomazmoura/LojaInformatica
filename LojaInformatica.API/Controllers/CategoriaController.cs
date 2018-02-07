using LojaInformatica.API.Dados;
using LojaInformatica.API.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace LojaInformatica.API.Controllers
{
    public class CategoriaController : Controller, IEntidadeApi<Categoria>
    {
        private readonly IRepositorio _repositorio;
        public CategoriaController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categorias = _repositorio.Categorias;
            return Ok(categorias);
        }

        [HttpGet("{id}", Name = "ConsultarCategoria")]
        public IActionResult Get(int id)
        {
            var categoria = _repositorio.Categorias
                .PorId(id);

            if (categoria == null)
                return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria entidade)
        {
            if (entidade == null || !entidade.EstaValidoParaInsercao)
                return BadRequest();

            _repositorio.Acrescentar(entidade);

            return CreatedAtRoute("ConsultarCategoria", new { id = entidade.Id }, entidade);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Categoria entidade)
        {
            if (entidade == null || !entidade.EstaValidoParaAtualizacao)
                return BadRequest();

            if (!_repositorio.Categorias.ConstaNoBanco(entidade.Id))
                return NotFound();

            _repositorio.Atualizar(entidade);

            return NoContent();
        }

        public IActionResult Delete(int id)
        {
            if (!_repositorio.Categorias.ConstaNoBanco(id))
                return NotFound();

            _repositorio.Remover<Categoria>(id);

            return NoContent();
        }
    }
}