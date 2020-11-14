using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QPH.Eval.Ej1.Business;
using QPH.Eval.Ej1.Core.Models;
using QPH.Eval.Ej1.Models;
using QPH.Eval.Ej1.Repository;

namespace QPH.Eval.Ej1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        

        public IActionResult Index()
        {
            var libroRepository = new LibroRepository(new QPHContext(_configuration.GetConnectionString("QPHDB")));

            var librosBusiness = new LibrosBusiness(libroRepository);
            var test = librosBusiness.GetLibros(1,"Nombre",null, Core.SortingEnum.None,null);
            return View();
        }

        public IActionResult Privacy()
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
