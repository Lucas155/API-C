using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {

        static HttpClient produto = new HttpClient();

        public IActionResult Index()
        {

                List<Produtos> dbProdutos = new List<Produtos>();
                Task<String> response = produto.GetStringAsync("https://localhost:44372/api/values"); 
               // string allProdutos = (response.Result).Replace("[", "").Replace("]", "").Replace("},{", "}},{{"); 

                List<Produtos> logs = JsonConvert.DeserializeObject<List<Produtos>>(response.Result);

                return View(logs);    
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult CadastrarProdutos()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public async Task<IActionResult> insertProduto(Produtos produtos)
        {
            try
            {
                HttpResponseMessage response = await produto.PostAsJsonAsync("https://localhost:44372/api/values", produtos); //sends a POST request to API and send to the body the second parameter serialized 
                return RedirectToAction("Index"); // and returns to the Home Page
            }
            catch (Exception e)
            {
                string erro = e.GetBaseException().ToString(); // in case of error he simply keep the error message
                return RedirectToAction("Index"); // and returns to the Home Page
            }
        }
    }
}
