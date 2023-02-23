﻿using Microsoft.EntityFrameworkCore;

namespace Proyecto_ProgramacionWeb_1131119.Models
{
    public class dbHospital : DbContext
    {
        public dbHospital(DbContextOptions<dbHospital> opciones) : base(opciones) { }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Personal> Personal { get; set; }
        //public DbSet<PersonaPersonal> PersonaPersonal { get; set; }
        //public DbSet<Paciente> Paciente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-G63SKBD;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                options => options.EnableRetryOnFailure());
        }
    }
}
