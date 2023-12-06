using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using EstMVC.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace EstMVC.Controllers
{
    public class ItensController : Controller
    {
        public string uriBase = "http://EstoqueHAS.somee.com/EstAPI/Itens/";

        [HttpGet]
        public async Task<ActionResult> IndexAsync()
        {
            try
            {
                string uriComplementar = "GetAll";
                HttpClient httpClient = new HttpClient();

                HttpResponseMessage response =  await httpClient.GetAsync(uriBase + uriComplementar);
                string serialized = await response.Content.ReadAsStringAsync();

                if  (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    List<ItemViewModel> listaItens = await Task.Run(() =>
                    JsonConvert.DeserializeObject<List<ItemViewModel>>(serialized));           
                    
                    return View(listaItens);
                }
                else
                    throw new System.Exception(serialized);
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
    }


    }









}