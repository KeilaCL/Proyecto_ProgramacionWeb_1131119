using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto_ProgramacionWeb_1131119.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_ProgramacionWeb_1131119.Controllers
{
    public class HomeController : Controller
    {
        private readonly dbHospital _dbhospital;

        private readonly ILogger<HomeController> _logger;

        public HomeController(dbHospital dbhospital)
        {
            _dbhospital = dbhospital;
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return _dbhospital.Usuarios.ToList();
        }
        public IActionResult Index()
        {
            var usuarios = _dbhospital.Usuarios.ToList();
            return View(usuarios);
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registro()
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
