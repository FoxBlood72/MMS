using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MMS.Configurations
{
    public class MilitariySkillConfigurator : IEntityTypeConfiguration<MilitarySkill>
    {
        public void Configure(EntityTypeBuilder<MilitarySkill> builder)
        {
            builder.HasOne(x => x.skill).WithMany(y => y.MilitarysSkills).HasForeignKey(x => x.skillId);
            builder.HasOne(x => x.military).WithMany(y => y.MilitarysSkills).HasForeignKey(x => x.militaryId);
            //builder.Property(x => x.militaryGrade).HasColumnType("float");
        }
    }
}
