using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        ProdutosRepository produtoRepository = new ProdutosRepository();

        [HttpGet]
        public List<Produtos> ListaProdutos()
        {
            return produtoRepository.ListProdutos();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Produtos ListProdutoId(int id)
        {
            return produtoRepository.ListProdutoId(id);
        }

        string status = "";
        // POST api/values
        [HttpPost]
        public string Insert([FromBody] Produtos produtos)
        {
            try
            {
                produtoRepository.Insert(produtos);
                status = "Produto cadastrado";
            }
            catch (Exception e)
            {
                status = e.GetBaseException().ToString();
            }

            return status;
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public string Update([FromBody] Produtos produtos, int id)
        {
            try
            {
                produtoRepository.Update(id, produtos);
                status = "Produto atualizado updated";
            }
            catch (Exception e)
            {
                status = e.GetBaseException().ToString();
            }

            return status;
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                produtoRepository.Delete(id);
                status = "Produto deletado";
            }
            catch(Exception e)
            {
                status = e.GetBaseException().ToString();
            }

            return status;
        }

      
    }
}
