using System.ComponentModel.DataAnnotations;

namespace API_Proyecto_ProgramacionWeb.Models
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }
        public string DPI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }

        //Llaves foraneas
        //public ICollection<Paciente> Paciente { get; set; }
        //public ICollection<Personal> Personal { get; set; }
    }
}
