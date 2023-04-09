using Microsoft.AspNetCore.Mvc;
using API_Proyecto_ProgramacionWeb.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Proyecto_ProgramacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        // GET: api/<PersonasController>
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

        // GET api/<PersonasController>/5
        [Route("Get")]
        [HttpPost]
        public Persona Get(int id)
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

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
