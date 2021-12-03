using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ObjectMappings
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryId).HasColumnType("int");
            builder.Property(x => x.Name).HasColumnType("varchar(50)");
            builder.Property(x => x.Description).HasColumnType("varchar(150)");
            builder.Property(x => x.Status).HasColumnType("bit");
            builder.Property(x => x.CreatedDate).HasColumnType("Datetime");
            builder.Property(x => x.UpdatedDate).HasColumnType("Datetime");

            builder.Property(x => x.CategoryId).HasColumnName("CategoryId");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.Description).HasColumnName("Description");
            builder.Property(x => x.Status).HasColumnName("Status");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate");

            builder.ToTable("Categories");
        }
    }
}
