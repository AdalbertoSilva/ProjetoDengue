using ProjetoDengue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDengue.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Campo campo = Campo.Instance;
            if (campo.TamanhoX != 0 || campo.TamanhoY != 0)
            {
                return View("Ambiente");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Ambiente(int quantidadeMosquitos, int quantidadeAgentesSanitarios, int quantidadePessoas, int tamanhoX, int tamanhoY)
        {
            Campo campo = Campo.Instance;
            if (campo.TamanhoX == 0 || campo.TamanhoY == 0)
            {
                campo.CriarCampo(tamanhoX, tamanhoY);
                campo.QuantidadeCiclos = 0;
                AgenteFactory agenteFactory = new AgenteFactory();
                int quantidadeMosquitosMachos = 0;
                int quantidadeMosquitosFemeas = 0;
                if (quantidadeMosquitos > 1)
                {
                    quantidadeMosquitosMachos = quantidadeMosquitos / 2;
                }
                quantidadeMosquitosFemeas = quantidadeMosquitos - quantidadeMosquitosMachos;
                agenteFactory.AdicionarAgentesALista(quantidadeMosquitosMachos, "MosquitoMacho");
                agenteFactory.AdicionarAgentesALista(quantidadeMosquitosFemeas, "MosquitoFemea");
                agenteFactory.AdicionarAgentesALista(quantidadeAgentesSanitarios, "AgenteSanitario");
                agenteFactory.AdicionarAgentesALista(quantidadePessoas, "Pessoa");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chat()
        {
            return View();
        }
    }
}