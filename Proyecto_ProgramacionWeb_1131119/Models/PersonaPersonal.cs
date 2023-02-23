using System.Collections.Generic;

namespace Proyecto_ProgramacionWeb_1131119.Models
{
    public class PersonaPersonal
    {
        public Persona persona { get; set; }
        public IEnumerable<Personal> personal { get; set; }
    }
}
