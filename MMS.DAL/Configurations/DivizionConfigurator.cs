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
    public class DivizionConfigurator : IEntityTypeConfiguration<Divizion>
    {
        public void Configure(EntityTypeBuilder<Divizion> builder)
        {
            builder.HasKey(x => x.DivizionID);
            builder.Property(x => x.DivizionName).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.FoundDate).HasColumnType("Date").HasDefaultValue("GetDate()");
            builder.Property(x => x.type).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.HasOne(x => x.Corp).WithMany(y => y.divizions);
        }

    }
}
