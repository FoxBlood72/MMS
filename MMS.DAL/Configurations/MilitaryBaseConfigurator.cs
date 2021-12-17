using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MMS.Configurations
{
    public class MilitaryBaseConfigurator : IEntityTypeConfiguration<MilitaryBase>
    {
        public void Configure(EntityTypeBuilder<MilitaryBase> builder)
        {
            builder.HasKey(x => x.IdBase);
            builder.HasOne(x => x.state).WithMany(y => y.bases);
            builder.HasOne(x => x.location).WithMany(y => y.bases);
            builder.Property(x => x.BaseName).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.FoundDate).HasColumnType("Date").HasDefaultValueSql("GetDate()");
        }

    }
}
