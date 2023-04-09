using System.ComponentModel.DataAnnotations;

namespace API_Proyecto_ProgramacionWeb.Models
{
    public class Personal
    {
        [Key]
        public int IdPersonal { get; set; }
        public int IdPersona { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public decimal Salario { get; set; }
    }
}
