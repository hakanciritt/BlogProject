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
    public class WriterConfiguration : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.HasKey(x => x.WriterId);
            builder.Property(x => x.WriterId).HasColumnType("int");
            builder.Property(x => x.Name).HasColumnType("varchar(70)");
            builder.Property(x => x.About).HasColumnType("varchar(max)");
            builder.Property(x => x.Mail).HasColumnType("varchar(50)");
            builder.Property(x => x.Status).HasColumnType("bit");
            builder.Property(x => x.Password).HasColumnType("varchar(100)");
            builder.Property(x => x.Image).HasColumnType("varchar(200)");

            builder.Property(x => x.WriterId).HasColumnName("WriterId");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.About).HasColumnName("About");
            builder.Property(x => x.Mail).HasColumnName("Mail");
            builder.Property(x => x.Status).HasColumnName("Status");
            builder.Property(x => x.Password).HasColumnName("Password");
            builder.Property(x => x.Image).HasColumnName("Image");

            builder.ToTable("Writers");
        }
    }
}
