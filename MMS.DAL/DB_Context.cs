using Microsoft.EntityFrameworkCore;
using MMS.Configurations;
using MMS.DAL.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DAL
{
    public class DB_Context : DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        {

        }

        public DbSet<PersonalMilitary> Militaries { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Conflict> Conflicts { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<MilitaryBase> Bases { get; set; } 
        public DbSet<Mission> Missions { get; set; }
        public DbSet<ArmyCorp> Corps { get; set; }
        
        public DbSet<Divizion> Divizions { get; set; }
        public DbSet<Garrison> Garrisons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MilitaryConfigurator());
            modelBuilder.ApplyConfiguration(new LeaderConfigurator());
            modelBuilder.ApplyConfiguration(new StateConfigurator());
            modelBuilder.ApplyConfiguration(new LocationConfigurator());
            modelBuilder.ApplyConfiguration(new ConflictConfigurator());
            modelBuilder.ApplyConfiguration(new StateConfigurator());
            modelBuilder.ApplyConfiguration(new MilitaryBaseConfigurator());
            modelBuilder.ApplyConfiguration(new MissionConfigurator());
            modelBuilder.ApplyConfiguration(new ArmyCorpConfigurator());
            modelBuilder.ApplyConfiguration(new GarrisonConfigurator());
            modelBuilder.ApplyConfiguration(new SkillConfigurator());
        }


    }
}
