using LojaInformatica.API.Dados;
using LojaInformatica.API.Entidades;
using LojaInformatica.API.Objetos;
using Microsoft.AspNetCore.Mvc;

namespace LojaInformatica.API.Controllers
{
    [Route("api/clientes")]
    public class ClienteController : Controller, IEntidadeApi<Cliente>
    {
        private readonly IRepositorio _repositorio;
        public ClienteController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Get()
        {
            return Get(new PaginacaoDeCliente());
        }

        [HttpGet]
        public IActionResult Get(PaginacaoDeCliente paginacaoDeCliente)
        {
            var clientes = _repositorio.Clientes;
            if (!string.IsNullOrEmpty(paginacaoDeCliente.FiltroPorNome))
                clientes = clientes.PorNome(paginacaoDeCliente.FiltroPorNome);

            return Ok(clientes.Paginar(paginacaoDeCliente));
        }

        [HttpGet("{id}", Name = "ConsultarCliente")]
        public IActionResult Get(int id)
        {
            var cliente = _repositorio.Clientes
                .PorId(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            if (!cliente.EstaValidoParaInsercao)
                return BadRequest();

            _repositorio.Acrescentar(cliente);
            return CreatedAtRoute("ConsultarCliente", new
            {
                id = cliente.Id
            }, cliente);
        }

        [HttpPut()]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            if (cliente == null || !cliente.EstaValidoParaAtualizacao)
                return BadRequest();

            if (!_repositorio.Clientes.ConstaNoBanco(cliente.Id))
                return NotFound();

            _repositorio.Atualizar(cliente);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            if (!_repositorio.Clientes.ConstaNoBanco(id))
                return NotFound();

            _repositorio.Remover(new Cliente { Id = id });

            return NoContent();
        }
    }
}
