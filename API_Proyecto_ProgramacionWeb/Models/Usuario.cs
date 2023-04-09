using System.ComponentModel.DataAnnotations;

namespace API_Proyecto_ProgramacionWeb.Models
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
