using System.ComponentModel.DataAnnotations;

namespace Proyecto_ProgramacionWeb_1131119.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public int IdPersona { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

    }
}
