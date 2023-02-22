using Microsoft.EntityFrameworkCore;

namespace Proyecto_ProgramacionWeb_1131119.Models
{
    public class dbHospital : DbContext
    {
        public dbHospital(DbContextOptions<dbHospital> opciones) : base(opciones) { }

        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<Paciente> Personal { get; set; }
        //public DbSet<Paciente> Pacientes { get; set; }

    }
}
