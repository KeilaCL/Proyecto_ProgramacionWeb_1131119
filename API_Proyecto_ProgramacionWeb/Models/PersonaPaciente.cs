namespace API_Proyecto_ProgramacionWeb.Models
{
    public class PersonaPaciente
    {
        public Persona persona { get; set; }
        public Paciente paciente { get; set; }
        public Usuario usuario { get; set; }
    }
}
