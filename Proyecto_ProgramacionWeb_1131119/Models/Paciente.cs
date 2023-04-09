﻿using System.ComponentModel.DataAnnotations;

namespace Proyecto_ProgramacionWeb_1131119.Models
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
