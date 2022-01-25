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

            builder.HasMany(x => x.missions).WithMany(y => y.armyCorps).UsingEntity<ArmyCorpMission>(
                j => j.HasOne(t => t.mission).WithMany(y => y.armyCorpMissions).HasForeignKey(y => y.missionId),
                j => j.HasOne(t => t.armyCorp).WithMany(y => y.armyCorpMissions).HasForeignKey(y => y.armycorpId),
                j => {
                    j.HasKey(t => new { t.missionId, t.armycorpId });
                    j.Property(t => t.startDate).HasColumnType("Date").HasDefaultValueSql("GetDate()");
                    j.Property(t => t.endDate).HasColumnType("Date");
                    j.Property(t => t.isVictory).HasColumnType("int");
                    }
                );
            
        }
    }
}
