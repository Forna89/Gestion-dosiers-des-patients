using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace gestion_dossier_patient.models
{
    public class MedecinContext : IdentityDbContext
    {
        //dbset pour manipuler l'objet medecin 

        public DbSet<Medecins> medecin { get; set; }
        public DbSet<Consultation> consultation { get; set; }
        public DbSet<Dossier_patient> dossier_patient { get; set; }
        public DbSet<Prescription> prescription { get; set; }
        public DbSet<AppUser> AppUser { get; set; }

        public MedecinContext(DbContextOptions options) : base(options)
        {

        }

       
    }
}
