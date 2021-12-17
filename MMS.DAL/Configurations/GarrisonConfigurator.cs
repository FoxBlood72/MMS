using MMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMS.Configurations
{
    public class GarrisonConfigurator : IEntityTypeConfiguration<Garrison>
    {
        public void Configure(EntityTypeBuilder<Garrison> builder)
        {
            builder.HasKey(x => x.id_garrison);
            builder.HasOne(x => x.MilitaryBase).WithMany(y => y.Garrison);
            builder.Property(x => x.start_date).HasColumnType("Date").HasDefaultValueSql("GetDate()");
            builder.Property(x => x.available_rooms).HasColumnType("int");
            builder.Property(x => x.name).HasColumnType("nvarchar(100)").HasMaxLength(100);
        }

    }
}
