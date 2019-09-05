using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication.Models;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {

        static HttpClient produto = new HttpClient();

        public IActionResult Index()
        {

                List<Produtos> dbProdutos = new List<Produtos>();
                Task<String> response = produto.GetStringAsync("https://localhost:44372/api/values"); 

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

        public IActionResult EditarProdutos(Produtos produtos)
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
                HttpResponseMessage response = await produto.PostAsJsonAsync("https://localhost:44372/api/values", produtos); 
                return RedirectToAction("Index"); 
            }
            catch (Exception e)
            {
                string erro = e.GetBaseException().ToString(); 
                return RedirectToAction("Index"); 
            }
        }

        public async Task<IActionResult> UpdateProdutos(string _id, Produtos produtos)
        {
            try
            {
                //produtos._id;   
                string DadosProdutos = JsonConvert.SerializeObject(produtos);

                JObject jsonProduto = JObject.Parse(DadosProdutos); 

                HttpResponseMessage response = await produto.PutAsJsonAsync("https://localhost:44372/api/values" + _id, jsonProduto); 
                return RedirectToAction("Index"); 
            }
            catch (Exception e)
            {
                string erro = e.GetBaseException().ToString();
                return RedirectToAction("Index");
            }
        }


        public async Task<IActionResult> Delete(string id )
        {
            
            try
            {
          
                    HttpResponseMessage response = await produto.DeleteAsync("https://localhost:44372/api/values" + id); 
                

                return RedirectToAction("Index"); //
            }
            catch (Exception e)
            {
                string erro = e.GetBaseException().ToString(); // in case of error he simply keep the error message
                return RedirectToAction("Index"); // and returns to the Home Page
            }
        }
    }
}
