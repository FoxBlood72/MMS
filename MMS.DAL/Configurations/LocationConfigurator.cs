using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MMS.Configurations
{
    public class LocationConfigurator : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.id_location);
            builder.Property(x => x.name).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.province).HasColumnType("nvarchar(100)").HasMaxLength(100);
        }

    }
}
