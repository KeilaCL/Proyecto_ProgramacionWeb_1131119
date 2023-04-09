using System.ComponentModel.DataAnnotations;

namespace API_Proyecto_ProgramacionWeb.Models
{
    public class Paciente
    {
        [Key]
        public int IdPaciente { get; set; }
        public int IdPersona { get; set; }
        public decimal Peso { get; set; }
        public decimal Estatura { get; set; }
    }
}
