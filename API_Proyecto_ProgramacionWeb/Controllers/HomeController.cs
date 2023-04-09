using API_Proyecto_ProgramacionWeb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Proyecto_ProgramacionWeb.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/<HomeController>
        [Route("GetListPersona")]
        [HttpPost]
        public async Task<IEnumerable<Persona>> GetListPersona()
        {
            dbHospital _hospitalContext = new dbHospital();
            IEnumerable<Persona> personas = _hospitalContext.Persona.Select(s =>
            new Persona
            {
                IdPersona = s.IdPersona,
                DPI = s.DPI,
                Nombre = s.Nombre,
                Apellido = s.Apellido,
                FechaNacimiento = s.FechaNacimiento,
                Telefono = s.Telefono,
                Correo = s.Correo,
                Direccion = s.Direccion,
                Sexo = s.Sexo,
            }
            ).ToList();
            return personas;
        }

        [Route("GetListPersonal")]
        [HttpPost]
        public async Task<IEnumerable<Personal>> GetListPersonal()
        {
            dbHospital _hospitalContext = new dbHospital();
            IEnumerable<Personal> personals = _hospitalContext.Personal.Select(s =>
            new Personal
            {
                IdPersona = s.IdPersona,
                IdPersonal = s.IdPersonal,
                Fecha_Ingreso = s.Fecha_Ingreso,
                Salario = s.Salario,
            }
            ).ToList();
            return personals;
        }

        [Route("GetListPaciente")]
        [HttpPost]
        public async Task<IEnumerable<Paciente>> GetListPaciente()
        {
            dbHospital _hospitalContext = new dbHospital();
            IEnumerable<Paciente> pacientes = _hospitalContext.Paciente.Select(s =>
            new Paciente
            {
                IdPersona = s.IdPersona,
                IdPaciente = s.IdPaciente,
                Peso = s.Peso,
                Estatura = s.Estatura,
            }
            ).ToList();
            return pacientes;
        }

        [Route("GetListUsuario")]
        [HttpPost]
        public async Task<IEnumerable<Usuario>> GetListUsuario()
        {
            dbHospital _hospitalContext = new dbHospital();
            IEnumerable<Usuario> usuarios = _hospitalContext.Usuario.Select(s =>
            new Usuario
            {
                IdUsuario = s.IdUsuario,
                IdPersona = s.IdPersona,
                NombreUsuario = s.NombreUsuario,
                Contraseña = s.Contraseña,
            }
            ).ToList();
            return usuarios;
        }

        //usuario
        [Route("GetUsuario")]
        [HttpPost]
        public Usuario GetUsuario(int id)
        {
            dbHospital _hospitalContext = new dbHospital();
            Usuario usuarios = _hospitalContext.Usuario.Select(s =>
            new Usuario
            {
                IdUsuario = s.IdUsuario,
                IdPersona = s.IdPersona,
                NombreUsuario = s.NombreUsuario,
                Contraseña = s.Contraseña,
            }
            ).FirstOrDefault(s => s.IdUsuario == id);
            return usuarios;
        }

        [Route("GetUsuarioE")]
        [HttpPost]
        public Usuario GetUsuario(string Nombre, string Contraseña)
        {
            dbHospital _hospitalContext = new dbHospital();
            Usuario usuarios = _hospitalContext.Usuario.Select(s =>
            new Usuario
            {
                IdUsuario = s.IdUsuario,
                IdPersona = s.IdPersona,
                NombreUsuario = s.NombreUsuario,
                Contraseña = s.Contraseña,
            }
            ).FirstOrDefault(s => s.NombreUsuario == Nombre && s.Contraseña == Contraseña) ;
            return usuarios;
        }
        [Route("GetPersona")]
        [HttpPost]
        public Persona GetPersona(int id)
        {
            dbHospital _hospitalContext = new dbHospital();
            Persona personas = _hospitalContext.Persona.Select(s =>
            new Persona
            {
                IdPersona = s.IdPersona,
                DPI = s.DPI,
                Nombre = s.Nombre,
                Apellido = s.Apellido,
                FechaNacimiento = s.FechaNacimiento,
                Telefono = s.Telefono,
                Correo = s.Correo,
                Direccion = s.Direccion,
                Sexo = s.Sexo,
            }
            ).FirstOrDefault(s => s.IdPersona == id);
            return personas;
        }
        [Route("GetUsuarioP")]
        [HttpPost]
        public Usuario GetUsuarioP(int id)
        {
            dbHospital _hospitalContext = new dbHospital();
            Usuario usuarios = _hospitalContext.Usuario.Select(s =>
            new Usuario
            {
                IdUsuario = s.IdUsuario,
                IdPersona = s.IdPersona,
                NombreUsuario = s.NombreUsuario,
                Contraseña = s.Contraseña,
            }
            ).FirstOrDefault(s => s.IdPersona == id);
            return usuarios;
        }

        //personal
        [Route("GetPersonal")]
        [HttpPost]
        public Personal GetPersonal(int id)
        {
            dbHospital _hospitalContext = new dbHospital();
            Personal personals = _hospitalContext.Personal.Select(s =>
            new Personal
            {
                IdPersona = s.IdPersona,
                IdPersonal = s.IdPersonal,
                Fecha_Ingreso = s.Fecha_Ingreso,
                Salario = s.Salario,
            }
            ).FirstOrDefault(s => s.IdPersona == id);
            return personals;
        }

        //paciente
        [Route("GetPaciente")]
        [HttpPost]
        public Paciente GetPaciente(int id)
        {
            dbHospital _hospitalContext = new dbHospital();
            Paciente pacientes = _hospitalContext.Paciente.Select(s =>
            new Paciente
            {
                IdPersona = s.IdPersona,
                IdPaciente = s.IdPaciente,
                Peso = s.Peso,
                Estatura = s.Estatura,
            }
            ).FirstOrDefault(s => s.IdPersona == id);
            return pacientes;
        }


        // POST api/<HomeController>
        [Route("PostPersona")]
        [HttpPost]
        public async Task<GeneralResult> SetPersona(Persona persona)
        {
            GeneralResult generalResult = new GeneralResult
            {
                Result = false
            };
            try
            {
                dbHospital _hospitalContext = new dbHospital();
                Persona persona1 = new Persona
                {
                    IdPersona = persona.IdPersona,
                    DPI = persona.DPI,
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    FechaNacimiento = persona.FechaNacimiento,
                    Telefono = persona.Telefono,
                    Correo = persona.Correo,
                    Direccion = persona.Direccion,
                    Sexo = persona.Sexo,
                };
                _hospitalContext.Persona.Add(persona1);
                await _hospitalContext.SaveChangesAsync();
                generalResult.Result = true;
                generalResult.ErrorMessage = persona1.IdPersona.ToString();
            }
            catch (Exception ex)
            {
                generalResult.Result = false;
                generalResult.ErrorMessage = ex.Message;
            }
            return generalResult;
        }

        [Route("PostPersonal")]
        [HttpPost]
        public async Task<GeneralResult> SetPersonal(Personal personal)
        {
            GeneralResult generalResult = new GeneralResult
            {
                Result = false
            };
            try
            {
                dbHospital _hospitalContext = new dbHospital();
                Personal personal1 = new Personal
                {
                    IdPersona = personal.IdPersona,
                    IdPersonal = personal.IdPersonal,
                    Fecha_Ingreso = personal.Fecha_Ingreso,
                    Salario = personal.Salario,
                };
                _hospitalContext.Personal.Add(personal1);
                await _hospitalContext.SaveChangesAsync();
                generalResult.Result = true;
            }
            catch (Exception ex)
            {
                generalResult.Result = false;
                generalResult.ErrorMessage = ex.Message;
            }
            return generalResult;
        }

        [Route("PostPaciente")]
        [HttpPost]
        public async Task<GeneralResult> SetPaciente(Paciente paciente)
        {
            GeneralResult generalResult = new GeneralResult
            {
                Result = false
            };
            try
            {
                dbHospital _hospitalContext = new dbHospital();
                Paciente paciente1 = new Paciente
                {
                    IdPersona = paciente.IdPersona,
                    IdPaciente = paciente.IdPaciente,
                    Peso = paciente.Peso,
                    Estatura = paciente.Estatura,
                };
                _hospitalContext.Paciente.Add(paciente1);
                await _hospitalContext.SaveChangesAsync();
                generalResult.Result = true;
            }
            catch (Exception ex)
            {
                generalResult.Result = false;
                generalResult.ErrorMessage = ex.Message;
            }
            return generalResult;
        }

        [Route("PostUsuario")]
        [HttpPost]
        public async Task<GeneralResult> SetUsuario(Usuario usuario)
        {
            GeneralResult generalResult = new GeneralResult
            {
                Result = false
            };
            try
            {
                dbHospital _hospitalContext = new dbHospital();
                Usuario usuario1 = new Usuario
                {
                    IdUsuario = usuario.IdUsuario,
                    IdPersona = usuario.IdPersona,
                    NombreUsuario = usuario.NombreUsuario,
                    Contraseña = usuario.Contraseña,
                };
                _hospitalContext.Usuario.Add(usuario1);
                await _hospitalContext.SaveChangesAsync();
                generalResult.Result = true;

            }
            catch (Exception ex)
            {
                generalResult.Result = false;
                generalResult.ErrorMessage = ex.Message;
            }
            return generalResult;
        }

        // PUT api/<HomeController>/5
        [Route("EditPersona")]
        [HttpPut]
        public async Task<GeneralResult> EditPersona(Persona _persona)
        {
            GeneralResult generalResult = new GeneralResult
            {
                Result = false
            };
            try
            {
                dbHospital _hospitalContext = new dbHospital();
                Persona persona = new Persona
                {
                    IdPersona = _persona.IdPersona,
                    DPI = _persona.DPI,
                    Nombre = _persona.Nombre,
                    Apellido = _persona.Apellido,
                    FechaNacimiento = _persona.FechaNacimiento,
                    Telefono = _persona.Telefono,
                    Correo = _persona.Correo,
                    Direccion = _persona.Direccion,
                    Sexo = _persona.Sexo,
                };
                _hospitalContext.Update(persona);
                await _hospitalContext.SaveChangesAsync();
                generalResult.Result = true;
            }
            catch (Exception ex)
            {
                generalResult.Result = false;
                generalResult.ErrorMessage = ex.Message;
            }
            return generalResult;
        }

        [Route("EditPersonal")]
        [HttpPut]
        public async Task<GeneralResult> EditPersonal(Personal _personal)
        {
            GeneralResult generalResult = new GeneralResult
            {
                Result = false
            };
            try
            {
                dbHospital _hospitalContext = new dbHospital();
                Personal personal = new Personal
                {
                    IdPersona = _personal.IdPersona,
                    IdPersonal = _personal.IdPersonal,
                    Fecha_Ingreso = _personal.Fecha_Ingreso,
                    Salario = _personal.Salario,
                };
                _hospitalContext.Update(personal);
                await _hospitalContext.SaveChangesAsync();
                generalResult.Result = true;
            }
            catch (Exception ex)
            {
                generalResult.Result = false;
                generalResult.ErrorMessage = ex.Message;
            }
            return generalResult;
        }

        [Route("EditPaciente")]
        [HttpPut]
        public async Task<GeneralResult> EditPaciente(Paciente _paciente)
        {
            GeneralResult generalResult = new GeneralResult
            {
                Result = false
            };
            try
            {
                dbHospital _hospitalContext = new dbHospital();
                Paciente paciente = new Paciente
                {
                    IdPersona = _paciente.IdPersona,
                    IdPaciente = _paciente.IdPaciente,
                    Peso = _paciente.Peso,
                    Estatura = _paciente.Estatura,
                };
                _hospitalContext.Update(paciente);
                await _hospitalContext.SaveChangesAsync();
                generalResult.Result = true;
            }
            catch (Exception ex)
            {
                generalResult.Result = false;
                generalResult.ErrorMessage = ex.Message;
            }
            return generalResult;
        }

        [Route("EditUsuario")]
        [HttpPut]
        public async Task<GeneralResult> EditUsuario(Usuario _usuario)
        {
            GeneralResult generalResult = new GeneralResult
            {
                Result = false
            };
            try
            {
                dbHospital _hospitalContext = new dbHospital();
                Usuario usuario = new Usuario
                {
                    IdUsuario = _usuario.IdUsuario,
                    IdPersona = _usuario.IdPersona,
                    NombreUsuario = _usuario.NombreUsuario,
                    Contraseña = _usuario.Contraseña,
                };
                _hospitalContext.Update(usuario);
                await _hospitalContext.SaveChangesAsync();
                generalResult.Result = true;
            }
            catch (Exception ex)
            {
                generalResult.Result = false;
                generalResult.ErrorMessage = ex.Message;
            }
            return generalResult;
        }

        [Route("DeletePersona")]
        [HttpDelete]
        public async Task<GeneralResult> DeletePersona(int id)
        {
            GeneralResult generalResult = new GeneralResult
            {
                Result = false
            };
            dbHospital _hospitalContext = new dbHospital();
           
                try
                {
                    var persona = await _hospitalContext.Persona.FindAsync(id);
                    if (persona == null)
                    {
                        generalResult.Result = false;
                        generalResult.ErrorMessage = "Persona not found.";
                        return generalResult;
                    }

                // Elimina el usuario con el id de la persona
                Usuario usuario = _hospitalContext.Usuario.Select(s =>
                   new Usuario
                   {
                       IdUsuario = s.IdUsuario,
                       IdPersona = s.IdPersona,
                       NombreUsuario = s.NombreUsuario,
                       Contraseña = s.Contraseña,
                   }
                   ).FirstOrDefault(s => s.IdPersona == id);

                Personal personal = _hospitalContext.Personal.Select(s =>
                   new Personal
                   {
                       IdPersona = s.IdPersona,
                       IdPersonal = s.IdPersonal,
                       Fecha_Ingreso = s.Fecha_Ingreso,
                       Salario = s.Salario,
                   }
                   ).FirstOrDefault(s => s.IdPersona == id);

                Paciente paciente = _hospitalContext.Paciente.Select(s =>
                   new Paciente
                   {
                       IdPersona = s.IdPersona,
                       IdPaciente = s.IdPaciente,
                       Peso = s.Peso,
                       Estatura = s.Estatura,
                   }
                   ).FirstOrDefault(s => s.IdPersona == id);

                if (usuario != null)
                    {
                        _hospitalContext.Usuario.Remove(usuario);
                    await _hospitalContext.SaveChangesAsync();
                    if (personal != null)
                        {
                            _hospitalContext.Personal.Remove(personal);
                        await _hospitalContext.SaveChangesAsync();
                    }
                        else if (paciente != null)
                        {
                            _hospitalContext.Paciente.Remove(paciente);
                        await _hospitalContext.SaveChangesAsync();
                    }
                    }

                    // Elimina la persona
                    _hospitalContext.Persona.Remove(persona);

                    await _hospitalContext.SaveChangesAsync();


                    generalResult.Result = true;
                    generalResult.ErrorMessage = "se elimino";
                    return generalResult;
                }
                catch (Exception ex)
                {
                    generalResult.ErrorMessage = ex.Message;
                }
                return generalResult;
        }
            // DELETE api/<HomeController>/5
        //    [Route("DeletePersona")]
        //[HttpDelete]
        //public async Task<GeneralResult> DeletePersona(int id)
        //{
        //    GeneralResult generalResult = new GeneralResult
        //    {
        //        Result = false
        //    };
        //    try
        //    {
        //        dbHospital _hospitalContext = new dbHospital();
        //        var movieToDelete = await _hospitalContext.Persona.FindAsync(id);
        //        if (movieToDelete == null)
        //        {
        //            generalResult.Result = false;
        //            generalResult.ErrorMessage = "Persona not found.";
        //            return generalResult;
        //        }
        //        _hospitalContext.Persona.Remove(movieToDelete);
        //        await _hospitalContext.SaveChangesAsync();
        //        generalResult.Result = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        generalResult.Result = false;
        //        generalResult.ErrorMessage = ex.Message;
        //    }
        //    return generalResult;
        //}
    }
}
