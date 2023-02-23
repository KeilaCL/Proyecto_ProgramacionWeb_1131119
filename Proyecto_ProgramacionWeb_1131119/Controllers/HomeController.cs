using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //[HttpGet]
        //public IEnumerable<Persona> Get()
        //{
        //    return _dbhospital.Persona.ToList();
        //}

        //public IActionResult Index()
        //{
        //    //var query = from cliente in _dbhospital.Persona
        //    //            join pedido in _dbhospital.Paciente on cliente.Id equals pedido.ClienteId
        //    //            select new { Cliente = cliente, Pedido = pedido };

        //    //var usuarios = _dbhospital.Persona.ToList();
        //    var usuarios = _dbhospital.Personal.ToList();
        //    //return View(usuarios);
        //    return View();
        //}

        public IActionResult Index()
        {
            var query = from persona in _dbhospital.Persona
                        join personal in _dbhospital.Personal on persona.IdPersona equals personal.IdPersona
                        select new {
                            persona.IdPersona,
                            persona.DPI,
                            persona.Nombre,
                            persona.Apellido,
                            persona.FechaNacimiento,
                            persona.Telefono,
                            persona.Correo,
                            persona.Direccion,
                            persona.Sexo,
                            personal.Salario,
                            personal.Fecha_Ingreso
                        };

            //var PersonaConPersonal = query.GroupBy(q => q.Persona)
            //                              .Select(g => new PersonaPersonal
            //                              {
            //                                  persona = g.Key,
            //                                  personal = g.Select(q => q.Personal)
            //                              })
            //                              .ToList();

            var results = query.ToList();

            //var usuarios = _dbhospital.Usuario.ToList();
            return View(results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        public IActionResult RegistroPersonal()
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
