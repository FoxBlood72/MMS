using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MMS.Configurations
{
    public class StateConfigurator : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(x => x.ID_STATE);
            builder.Property(x => x.name).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.id_leader).HasColumnType("int");
            builder.Property(x => x.population).HasColumnType("int");
            builder.Property(x => x.surface).HasColumnType("int");
            builder.Property(x => x.legislator).HasColumnType("nvarchar(100)").HasMaxLength(100);



        }

    }
}
