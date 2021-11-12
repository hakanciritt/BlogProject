using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ObjectMappings
{
    public class NatificationConfiguration : IEntityTypeConfiguration<Natification>
    {
        public void Configure(EntityTypeBuilder<Natification> builder)
        {
            builder.HasKey(x => x.NatificationId);
            builder.Property(x => x.NatificationId).HasColumnType("int");
            builder.Property(x => x.Details).HasColumnType("varchar(max)");
            builder.Property(x => x.Type).HasColumnType("varchar(max)");
            builder.Property(x => x.TypeSymbol).HasColumnType("varchar(150)");
            builder.Property(x => x.Status).HasColumnType("bit");
            builder.Property(x => x.Date).HasColumnType("datetime");

            builder.Property(x => x.NatificationId).HasColumnName("NatificationId");
            builder.Property(x => x.Details).HasColumnName("Details");
            builder.Property(x => x.Type).HasColumnName("Type");
            builder.Property(x => x.TypeSymbol).HasColumnName("TypeSymbol");
            builder.Property(x => x.Status).HasColumnName("Status");
            builder.Property(x => x.Date).HasColumnName("Date");

            builder.ToTable("Natifications");
        }
    }
}
