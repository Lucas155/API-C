using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebProdutos.Controller
{
    public class HomeControllers
    {

        static HttpClient produto = new HttpClient();

        
/*
        [HttpPost]
        public async Task<IActionResult> Insert_Client(Produtos produtos)
        {
            try
            {
                HttpResponseMessage response = await produto.PostAsJsonAsync("https://localhost:44335/api/values", produtos); //sends a POST request to API and send to the body the second parameter serialized 
                return RedirectToAction("Index"); // and returns to the Home Page
            }
            catch (Exception e)
            {
                string erro = e.GetBaseException().ToString(); // in case of error he simply keep the error message
                //return RedirectToAction("Index"); // and returns to the Home Page
            }
        }

       */
    }
}
