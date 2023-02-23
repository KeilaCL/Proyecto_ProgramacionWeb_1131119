using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Net;

namespace Proyecto_ProgramacionWeb_1131119.Models
{
    public class Personal
    {
        [Key]
        public int IdPersonal { get; set; }
        public int IdPersona { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public decimal Salario { get;set; }

        //llave foranea
        //public Persona Persona { get; set; }
    }
}
