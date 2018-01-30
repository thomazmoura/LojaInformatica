using LojaInformatica.API.Dados;
using LojaInformatica.API.Entidades;
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
            return Get(null);
        }

        [HttpGet]
        public IActionResult Get(string nome = null)
        {
            var clientes = _repositorio.Clientes;
            if (!string.IsNullOrEmpty(nome))
                clientes = clientes.PorNome(nome);

            return Ok(clientes);
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