using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoAPI.Model;

namespace MongoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutosService _produtosService;

        public ProdutosController(ProdutosService produtosService)
        {
            _produtosService = produtosService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Produtos>> Get() =>

           _produtosService.Get();
        

        // GET api/values/5
        [HttpGet("{id}", Name = "GetProdutos")]
        public ActionResult<Produtos> Get(string id)
        {
            var produto = _produtosService.Get(id);

            if(produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Produtos> Create(Produtos produtos)
        {
            _produtosService.Create(produtos);

            return CreatedAtRoute("GetProdutos", new { id = produtos.Id.ToString() }, produtos);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, Produtos produtos)
        {
            var produto = _produtosService.Get(id);

            if (produto == null)
            {
                return NotFound();
            }

            _produtosService.Update(id, produtos);

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var produto = _produtosService.Get(id);

            if (produto == null)
            {
                return NotFound();
            }

            _produtosService.Remove(produto.Id);

            return NoContent();
        }
    }
}
