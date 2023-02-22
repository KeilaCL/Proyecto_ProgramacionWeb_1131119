using System.ComponentModel.DataAnnotations;

namespace Proyecto_ProgramacionWeb_1131119.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        public int IdPersona { get; set; }
        public double Peso { get; set; }
        public double Estatura { get; set; }
    }
}
