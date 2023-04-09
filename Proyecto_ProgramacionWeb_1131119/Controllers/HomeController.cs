using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Proyecto_ProgramacionWeb_1131119.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proyecto_ProgramacionWeb_1131119.Controllers
{
    public class HomeController : Controller
    {
        private readonly dbHospital _dbhospital;
        private readonly ILogger<HomeController> _logger;
        static int idpersona = 0;
        static int idpersonal = 0;
        static int idpaciente = 0;
        static int idusuario = 0;

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
                        select new
                        {
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario usuario)
        {
            idpersona = 0;
            idusuario= 0;

            IEnumerable<Usuario> usuarios = await Functions.APIServices.GetUsuarioE(usuario.NombreUsuario, usuario.Contraseña);
            //var usuarios = from Usuario in _dbhospital.Usuario
            //               where Usuario.NombreUsuario == usuario.NombreUsuario && Usuario.Contraseña == usuario.Contraseña
            //               select Usuario;

            foreach (var u in usuarios)
            {
                idpersona = u.IdPersona;
                idusuario= u.IdUsuario;
            }
            //var personal = from Personal in _dbhospital.Personal
            //               where Personal.IdPersona == idpersona
            //               select Personal;
            IEnumerable<Personal> personal = await Functions.APIServices.PersonalGet(idpersona);

            foreach (var item in personal)
            {
                idpersonal = item.IdPersonal;
            }

            //var paciente = from Paciente in _dbhospital.Paciente
            //               where Paciente.IdPersona == idpersona
            //               select Paciente;
            IEnumerable<Paciente> paciente = await Functions.APIServices.PacienteGet(idpersona);
            foreach (var item2 in paciente)
            {
                idpaciente = item2.IdPaciente;
            }
           
            if (idpersona != 0)
            {
                return RedirectToAction("Principal", "Home");
            }
           

            TempData["Error"] = "Usuario o contraseña inválidos";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Principal()
        {
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registro(Persona persona, Paciente paciente, Usuario usuario, string Sexo)
        {
            if (ModelState.IsValid)
            {
                persona.Sexo= Sexo;
                int ultimoId = 0;
                bool re = false;
                IEnumerable<GeneralResult> result = await Functions.APIServices.PersonaSet(persona);

                foreach (var r in result)
                {
                    re = r.Result;
                    ultimoId = Convert.ToInt32(r.ErrorMessage);
                }
                //_dbhospital.Add(persona);
                //await _dbhospital.SaveChangesAsync();
                if (re)
                {
                    paciente.IdPersona = ultimoId;
                    usuario.IdPersona = ultimoId;
                    //_dbhospital.Add(paciente);
                    await Functions.APIServices.PostPaciente(paciente);
                    //_dbhospital.Add(usuario);
                    await Functions.APIServices.PostUsuario(usuario);
                    //await _dbhospital.SaveChangesAsync();
                    idpersona = persona.IdPersona;
                    idusuario = usuario.IdUsuario;
                    idpaciente = paciente.IdPaciente;
                    TempData["Error"] = "Usuario creado con exito";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Usuario no creado";
                    return RedirectToAction("Index", "Home");
                }
                
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> RegistroPersonal(Persona persona, Personal personal, Usuario usuario, string Sexo)
        {
            if (ModelState.IsValid)
            {
                persona.Sexo = Sexo;
                await Functions.APIServices.PersonaSet(persona);

                int ultimoId = persona.IdPersona;
                personal.IdPersona = ultimoId;
                usuario.IdPersona = ultimoId;
                //_dbhospital.Add(personal);
                await Functions.APIServices.PostPersonal(personal);
                //_dbhospital.Add(usuario);
                await Functions.APIServices.PostUsuario(usuario);
                //await _dbhospital.SaveChangesAsync();
                return RedirectToAction("Principal", "Home");
            }
            return View(usuario);
        }

        public IActionResult RegistroPersonal()
        {
            return View();
        }

        //public IActionResult Modificar()
        //{
        //    return View();
        //}
        //public IActionResult VerPersona()
        //{
        //    return View();
        //}

        public async Task<IActionResult> VerPersona(int id)
        {
            id = idpersona;
            IEnumerable<Persona> personas = await Functions.APIServices.PersonaGet(id);
            Persona objeto = new Persona();
            foreach (var p in personas)
            {
                objeto = p;
            }
            
            return View(objeto);
        }
        // GET: Personals/Edit/5
        public async Task<IActionResult> Modificar(int _idpersona, int _idusuario, int _idpaciente, int _idpersonal)
        {
            _idpersona = idpersona;
            _idpaciente= idpaciente;
            _idusuario= idusuario;
            _idpersonal= idpersonal;

            if (_idpersona == null)
            {
                return NotFound();
            }
            IEnumerable<Persona> personas = await Functions.APIServices.PersonaGet(_idpersona);
            Persona persona = new Persona();
            foreach (var p in personas)
            {
                persona = p;
            }
            IEnumerable<Usuario> usuarios = await Functions.APIServices.UsuarioGet(_idusuario);
            Usuario usuario = new Usuario();
            foreach (var u in usuarios)
            {
                usuario = u;
            }
            IEnumerable<Paciente> pacientes = await Functions.APIServices.PacienteGet(_idpersona);
            Paciente paciente = new Paciente();
            foreach (var p in pacientes)
            {
                paciente= p;
            }
            IEnumerable<Personal> personals = await Functions.APIServices.PersonalGet(_idpersona);
            Personal personal = new Personal();
            foreach (var p in personals)
            {
                personal= p;
            }
            //var persona = await _dbhospital.Persona.FindAsync(_idpersona);
            //var usuario = await _dbhospital.Usuario.FindAsync(_idusuario);
            //var paciente = await _dbhospital.Paciente.FindAsync(_idpaciente);
            //var personal = await _dbhospital.Personal.FindAsync(_idpersonal);
            var personapaciente = new PersonaPaciente();
            personapaciente.persona = persona;
            personapaciente.usuario= usuario;
            personapaciente.paciente = paciente;
            //personapaciente.personal= personal;
            if (persona == null)
            {
                return NotFound();
            }
            return View(personapaciente);
        }

        // POST: Personals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modificar(int id, [Bind("IdPersona,DPI,Nombre,Apellido,FechaNacimiento,Telefono,Correo,Direccion,Sexo")] Persona persona, [Bind("NombreUsuario,Contraseña")] Usuario usuario, [Bind("Peso,Estatura")] Paciente paciente)
        {
            id = idpersona;
            if (id != persona.IdPersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_dbhospital.Update(persona);
                    //await _dbhospital.SaveChangesAsync();
                    await Functions.APIServices.EditPersona(persona);

                    IEnumerable<Usuario> usuarios = await Functions.APIServices.UsuarioGetP(persona.IdPersona);
                    Usuario usuario2 = new Usuario();
                    foreach (var u in usuarios)
                    {
                        usuario2 = u;
                    }
                    usuario2.NombreUsuario = usuario.NombreUsuario;
                    usuario2.Contraseña = usuario.Contraseña;
                    await Functions.APIServices.EditUsuario(usuario2);

                    IEnumerable<Paciente> pacientes = await Functions.APIServices.PacienteGet(persona.IdPersona);
                    Paciente paciente2 = new Paciente();
                    foreach (var p in pacientes)
                    {
                        paciente2 = p;
                    }
                    paciente2.Estatura = paciente.Estatura;
                    paciente2.Peso = paciente.Peso;
                    await Functions.APIServices.EditPaciente(paciente2);

                    IEnumerable<Personal> personals = await Functions.APIServices.PersonalGet(persona.IdPersona);
                    Personal personal = new Personal();
                    foreach (var p in personals)
                    {
                        personal = p;
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.IdPersona))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["Error"] = "Usuario actualizado con exito";
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public async Task<IActionResult> Eliminar(int id)
        {
            id = idpersona;

            if (id == null)
            {
                return NotFound();
            }

            IEnumerable<Persona> personas = await Functions.APIServices.PersonaGet(id);
            Persona persona = new Persona();
            foreach (var p in personas)
            {
                persona = p;
            }
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([Bind("IdPersona,DPI,Nombre,Apellido,FechaNacimiento,Telefono,Correo,Direccion,Sexo")] Persona persona)
        {
            //id = idpersona;
            //int idpac = idpaciente;
            //int idper = idpersonal;
            //int idus = idusuario;
            //var usuario = await _dbhospital.Usuario.FindAsync(idus);
            //var paciente = await _dbhospital.Paciente.FindAsync(idpac);
            //var Personal = await _dbhospital.Personal.FindAsync(idper);
            //var persona = await _dbhospital.Persona.FindAsync(id);
            //_dbhospital.Paciente.Remove(paciente);
            //await _dbhospital.SaveChangesAsync();
            //_dbhospital.Usuario.Remove(usuario);
            //await _dbhospital.SaveChangesAsync();

            //_dbhospital.Persona.Remove(persona);
            //await _dbhospital.SaveChangesAsync();
            await Functions.APIServices.DeletePersona(persona.IdPersona);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool PersonaExists(int id)
        {
            return _dbhospital.Persona.Any(e => e.IdPersona == id);
        }
    }
}
