using System;

namespace Proyecto_ProgramacionWeb_1131119.Models
{
    public class CitaMedica
    {
        public int IdCita { get; set; }
        public int IdDoctor { get; set; }
        public int IdPaciente { get; set; }
        //Me hace falta el de hora pero no se si unirlo xd
        public DateTime FechaHoraCita { get; set; }
        public string Observaciones { get; set;}
    }
}
