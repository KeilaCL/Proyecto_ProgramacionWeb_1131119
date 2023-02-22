using System;

namespace Proyecto_ProgramacionWeb_1131119.Models
{
    public class Persona
    {
        public int IdPersona { get; set; }
        public int DPI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Sexo { get; set; }
    }
}
