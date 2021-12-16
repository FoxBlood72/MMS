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
    public class CommanderConfigurator : IEntityTypeConfiguration<Commander>
    {
        public void Configure(EntityTypeBuilder<Commander> builder)
        {
            builder.HasKey(x => x.id_personal);
            builder.Property(x => x.max_soldiers).HasColumnType("int");
        }

    }
}
