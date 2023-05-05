using System;
using Microsoft.EntityFrameworkCore;

namespace SkillUp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Training> trainings { get; set; }
        public DbSet<TrainingCenter> trainingCenters { get; set; }
        public DbSet<Candidat> candidats {get; set;}
        public DbSet<Manager> managers {get; set;}
        public DbSet<Achat> achats { get; set; }   
    }
}

