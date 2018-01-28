using LojaInformatica.Dados;
using LojaInformatica.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/produtos")]
    public class ProdutoController: Controller
    {
        private readonly IRepositorio _repositorio;
        public ProdutoController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _repositorio.Produtos;
            return Ok(produtos);
        }

        [HttpGet("{id}", Name="ConsultarProduto")]
        public IActionResult Get(int id)
        {
            var produto = _repositorio.Produtos
                .PorId(id);

            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Produto produto)
        {
            if(produto == null || !produto.EstaValidoParaInsercao)
                return BadRequest();

            _repositorio.Acrescentar(produto);
            
            return CreatedAtRoute("ConsultarProduto", new { id = produto.Id }, produto);
        }
        
        [HttpPut]
        public IActionResult Put([FromBody]Produto produto)
        {
            if(produto == null || !produto.EstaValidoParaAtualizacao)
                return BadRequest();

            if(!_repositorio.Produtos.ConstaNoBanco(produto.Id))
                return NotFound();
            
            _repositorio.Atualizar(produto);

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(id <= 0)
                return BadRequest();

            if(!_repositorio.Produtos.ConstaNoBanco(id))
                return NotFound();
            
            _repositorio.Remover<Produto>(id);

            return NoContent();
        }
    }
}