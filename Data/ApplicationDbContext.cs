using System;
using System.Collections.Generic;
using System.Text;
using DiarioEmocional.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DiarioEmocional.ModelView;

namespace DiarioEmocional.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Emocao> Emocoes { get; set; }
        public DbSet<Intensidade> Intensidades { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<DiarioEmocional.ModelView.RegistroPaciente> RegistroPaciente { get; set; }
            

    }
}
