using System;
using System.Data.SqlTypes;

namespace Proyecto_ProgramacionWeb_1131119.Models
{
    public class Personal
    {
        public int IdPersonal { get; set; }
        public int IdPersona { get; set; }
        public DateTime FechaIngreso { get; set;}
        public double Salario { get;set; }
    }
}
