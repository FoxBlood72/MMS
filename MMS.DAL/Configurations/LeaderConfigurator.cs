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
    public class LeaderConfigurator: IEntityTypeConfiguration<Leader>
    {
        public void Configure(EntityTypeBuilder<Leader> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.First_Name).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.Last_Name).HasColumnType("nvarchar(100)").HasMaxLength(100);
            builder.Property(x => x.sex).HasColumnType("nvarchar(2)").HasMaxLength(2);
            builder.Property(x => x.birth_date).HasColumnType("Date").HasDefaultValueSql("GetDate()");
        }

    }
}
