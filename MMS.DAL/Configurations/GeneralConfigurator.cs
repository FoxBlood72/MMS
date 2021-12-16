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
    public class GeneralConfigurator : IEntityTypeConfiguration<General>
    {
        public void Configure(EntityTypeBuilder<General> builder)
        {
            builder.HasKey(x => x.id_personal);
            builder.Property(x => x.max_div).HasColumnType("int");
        }

    }
}
