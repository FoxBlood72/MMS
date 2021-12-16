using MMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.DAL
{
    public class MissionConfigurator : IEntityTypeConfiguration<Mission>
    {
        public void Configure(EntityTypeBuilder<Mission> builder)
        {
            builder.HasKey(x => x.id_mission);
            builder.Property(x => x.name).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.description).HasColumnType("nvarchar(300)").HasMaxLength(300);
            builder.Property(x => x.start_date).HasColumnType("Date").HasDefaultValueSql("GetDate()");
            builder.Property(x => x.end_date).HasColumnType("Date").HasDefaultValueSql("GetDate()");
        }

    }
}
