using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using Microsoft.AspNetCore.Cors;

namespace Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        ProdutosRepository produtoRepository = new ProdutosRepository();

        [EnableCors("AllowMyOrigin")]
        [HttpGet]
        public List<Produtos> ListaProdutos()
        {
            return produtoRepository.ListProdutos();
        }

        // GET api/values/5
        [EnableCors("AllowMyOrigin")]
        [HttpGet("{id}")]
        public Produtos ListProdutoId(int id)
        {
            return produtoRepository.ListProdutoId(id);
        }

        string status = "";
        // POST api/values
        [EnableCors("AllowMyOrigin")]
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
        [EnableCors("AllowMyOrigin")]
        [HttpPut("{id}")]
         public string Update([FromBody] Produtos produtos, int id)
         {
             try
             {
                 produtoRepository.Update(id,produtos);
                 status = "Produto atualizado";
             }
             catch (Exception e)
             {
                 status = e.GetBaseException().ToString();
             }

             return status;
         }


        // DELETE api/values/5
        [EnableCors("AllowMyOrigin")]
        [HttpDelete("{id}")]
         public string Delete(int id)
         {
             try
             {
                 produtoRepository.DeleteProdutos(id);
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
