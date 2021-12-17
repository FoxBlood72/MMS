using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MMS.Configurations
{
    public class MilitaryConfigurator : IEntityTypeConfiguration<PersonalMilitary>
    {
        public void Configure(EntityTypeBuilder<PersonalMilitary> builder)
        {
            builder.HasKey(x => x.ID_PERS);

            builder.Property(x => x.firstname).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.lastname).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.sex).HasColumnType("nvarchar(2)").HasMaxLength(2);
            builder.Property(x => x.salary).HasColumnType("float(20,2)").HasMaxLength(20).HasPrecision(2);
            builder.Property(x => x.hire_date).HasColumnType("Date").HasDefaultValueSql("GetDate()");
            builder.HasOne(x => x.divizion).WithMany(y => y.personalMilitaries);
            builder.HasOne(x => x.mBase).WithMany(y => y.personalMilitaries);
        }
    }
}
