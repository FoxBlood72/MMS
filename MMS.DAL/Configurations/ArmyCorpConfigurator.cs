using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MMS.Configurations
{
    public class ArmyCorpConfigurator : IEntityTypeConfiguration<ArmyCorp>
    {
        public void Configure(EntityTypeBuilder<ArmyCorp> builder)
        {
            builder.HasKey(x => x.CorpId);
            builder.HasOne(x => x.state).WithMany(y => y.corps);
            builder.HasOne(x => x.Commander);
            builder.Property(x => x.victories).HasColumnType("int");
            builder.Property(x => x.defeates).HasColumnType("int");
            
        }
    }
}
