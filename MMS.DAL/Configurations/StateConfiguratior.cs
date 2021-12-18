using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

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

            builder.HasMany(x => x.conflicts).WithMany(y => y.states1).UsingEntity<StateConflict>(
                j => j.HasOne(x => x.conflict).WithMany(y => y.stateConflicts).HasForeignKey(j => j.conflictId),
                j => j.HasOne(x => x.state1).WithMany(y => y.state1Conflicts).HasForeignKey(j => j.state1Id),
                j => {
                    j.HasKey(t => new { t.conflictId, t.state1Id });
                    j.HasOne(x => x.state2).WithMany(y => y.state2Conflicts).HasForeignKey(j => j.state2Id);
                }
                //j => j.Property(x
                //j => j.HasOne(x => x.state2).WithMany(y => y.state2Conflicts).HasForeignKey(j => j.state2Id)
                //j => j.HasKey(t => new { t.conflictId })
                ) ;

            /*builder.HasMany(x => x.conflicts).WithMany(y => y.states2).UsingEntity<StateConflict>(
                j => j.HasOne(x => x.conflict).WithMany(y => y.stateConflicts).HasForeignKey(j => j.conflictId),
                j => j.HasOne(x => x.state1).WithMany(y => y.state1Conflicts).HasForeignKey(j => j.state1Id),
                j => j.HasOne(x => x.state2).WithMany(y => y.state2Conflicts).HasForeignKey(j => j.state2Id)
                //j => j.HasKey(t => new { t.conflictId })
                );
            */


        }

    }
}
