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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MilitaryConfigurator());
            modelBuilder.ApplyConfiguration(new LeaderConfigurator());
        }


    }
}
