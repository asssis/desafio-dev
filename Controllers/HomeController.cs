using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using desafio_dev.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using desafio_dev.Migrations;

namespace desafio_dev.Controllers
{
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            var context = new ConectionSQLite();
             List<Transacao> transacao = context.Transacao.ToList(); 
            return View(transacao);
        }
        public IActionResult Visualizar()
        {
            var context = new ConectionSQLite();
            List<Cnab> cnab = context.Cnab.ToList(); 
            return View(cnab);
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
            if(file == null)
                return RedirectToAction("New");


            var reader = new StreamReader(file.OpenReadStream());
            
                while (reader.Peek() >= 0){
                    string linha = reader.ReadLine();


                    Cnab cnab = new Cnab();
                    cnab.Transacao = transacao;
                    cnab.Tipo = Convert.ToInt32(linha.Substring(0,1));  
                    cnab.setDateTime(linha.Substring(1, 8), linha.Substring(42, 6));
                    cnab.Valor = Convert.ToDouble(linha.Substring(9, 8));
                    cnab.Cpf = linha.Substring(17, 11);
                    cnab.Cartao = linha.Substring(28, 14); 
                    cnab.DonoLoja = linha.Substring(48, 14);
                    cnab.NomeLoja = linha.Substring(60, 19); 
  
                    context.Cnab.Add(cnab);

                }
            
            context.SaveChanges();
            
            return RedirectToAction("Index");
        }

    }
}
