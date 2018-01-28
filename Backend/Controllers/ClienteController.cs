using LojaInformatica.Dados.Repositorios;
using LojaInformatica.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace LojaInformatica.Controllers
{
    [Route("api/clientes")]
    public class ClienteController: Controller
    {
        private readonly IRepositorio _repositorio;
        public ClienteController(IRepositorio repositorio){
            _repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult Get(string nome)
        {
            var clientes = _repositorio.Clientes;
            if(!string.IsNullOrEmpty(nome))
                clientes = clientes.PorNome(nome);

            return Ok(clientes);
        }

        [HttpGet("{id}", Name = "ConsultarCliente")]
        public IActionResult Get(int id)
        {
            var clientes = _repositorio.Clientes
                .PorId(id);
            return Ok(clientes);
        }

        [HttpPost()]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            _repositorio.Acrescentar(cliente);
            return CreatedAtRoute("ConsultarCliente", new {
                id = cliente.Id
            }, cliente);
        }
    }
}