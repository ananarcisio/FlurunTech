using InVents.Data;
using InVents.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace InVents.Controllers
{
    public class HomeController : Controller
    {
        private readonly InVentsContext _context;
        private readonly ILogger<HomeController> _logger;

        // Construtor que recebe as dependências de contexto e logger
        public HomeController(InVentsContext context, ILogger<HomeController> logger)
        {
            _logger = logger;    // Inicializa o logger
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            return View();
        }

        public IActionResult Contato()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
