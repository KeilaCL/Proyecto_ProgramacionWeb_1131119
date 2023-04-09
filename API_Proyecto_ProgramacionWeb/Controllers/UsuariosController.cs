using Microsoft.AspNetCore.Mvc;
using API_Proyecto_ProgramacionWeb.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Proyecto_ProgramacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // GET: api/<UsuariosController>
        [Route("GetList")]
        [HttpPost]
        public async Task<IEnumerable<Usuario>> GetList()
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

        // GET api/<UsuariosController>/5
        [Route("Get")]
        [HttpPost]
        public Usuario Get(int id)
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

        // POST api/<UsuariosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
