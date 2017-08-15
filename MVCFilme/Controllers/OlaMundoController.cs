using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCFilme.Controllers
{
    public class OlaMundoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public string BemVindo(string nome, int numVezes = 1)
        {
            return HtmlEncoder.Default.Encode($"Ola {nome}, o numero de vezes e igual a: {numVezes}.");
        }
    }
}
