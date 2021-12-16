using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MMS.Configurations
{
    class SkillConfigurator : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(x => x.IdSkill);
            builder.Property(x => x.SkillName).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.SkillDescription).HasColumnType("nvarchar(300)").HasMaxLength(300);
        }
    }
}
