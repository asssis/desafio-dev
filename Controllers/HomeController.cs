using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using desafio_ruby_on_rails.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using desafio_ruby_on_rails.Migrations;

namespace desafio_ruby_on_rails.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ILogger<HomeController> logger)
        { 
        }

        public IActionResult Index()
        {
            var context = new ConectionSQLite();
             List<Cnab> cnab =context.Cnab.ToList(); 
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IFormFile file)
        {   
            var context = new ConectionSQLite();
            Transacao transacao = new Transacao(){Data = DateTime.Now};
            context.Transacao.Add(transacao); 

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0){
                    string linha = reader.ReadLine();


                    Cnab cnab = new Cnab();
                    cnab.TransacaoId = transacao.Id;
                    cnab.Tipo = Convert.ToInt32(linha.Substring(0,1));
                    cnab.Data = linha.Substring(1, 8);
                    cnab.Valor = Convert.ToDouble(linha.Substring(9, 8));
                    cnab.Cpf = linha.Substring(17, 11);
                    cnab.Cartao = linha.Substring(28, 14);
                    cnab.Hora = linha.Substring(40, 6);
                    cnab.DonoLoja = linha.Substring(48, 14);
                    cnab.NomeLoja = linha.Substring(60, 19); 
  
                    context.Cnab.Add(cnab);
                    context.SaveChanges();

                }
            }    

            return View();           
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
