using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_ProgramacionWeb_1131119.Models
{
    public class Mantenimiento
    {
        public int IdMantenimiento { get; set; }
        public int IdPersonal { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string DescripcionTarea { get; set; }
    }
}
