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
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.BlogId);
            builder.Property(x => x.CategoryId).HasColumnType("int");
            builder.Property(x => x.Title).HasColumnType("varchar(100)");
            builder.Property(x => x.Content).HasColumnType("nvarchar(max)");
            builder.Property(x => x.ThumbnailImage).HasColumnType("varchar(200)");
            builder.Property(x => x.Image).HasColumnType("varchar(100)");
            builder.Property(x => x.CreateDate).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit");
            builder.Property(x => x.Slug).HasColumnType("varchar(max)");
            builder.Property(x => x.UpdateDate).HasColumnType("datetime");

            builder.Property(x => x.BlogId).HasColumnName("BlogId");
            builder.Property(x => x.CategoryId).HasColumnName("CategoryId");
            builder.Property(x => x.Title).HasColumnName("Title");
            builder.Property(x => x.Content).HasColumnName("Content");
            builder.Property(x => x.ThumbnailImage).HasColumnName("ThumbnailImage");
            builder.Property(x => x.Image).HasColumnName("Image");
            builder.Property(x => x.CreateDate).HasColumnName("CreateDate");
            builder.Property(x => x.Status).HasColumnName("Status");
            builder.Property(x => x.Slug).HasColumnName("Slug");
            builder.Property(x => x.UpdateDate).HasColumnName("UpdateDate");

            builder.ToTable("Blogs");

        }
    }
}
