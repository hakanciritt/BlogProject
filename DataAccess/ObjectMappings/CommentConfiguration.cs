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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.CommentId);
            builder.Property(x => x.BlogId).HasColumnType("int");
            builder.Property(x => x.UserName).HasColumnType("varchar(50)");
            builder.Property(x => x.Title).HasColumnType("varchar(100)");
            builder.Property(x => x.Content).HasColumnType("nvarchar(max)");
            builder.Property(x => x.Date).HasColumnType("datetime");
            builder.Property(x => x.Status).HasColumnType("bit");

            builder.Property(x => x.CommentId).HasColumnName("CommentId");
            builder.Property(x => x.Content).HasColumnName("Content");
            builder.Property(x => x.BlogId).HasColumnName("BlogId");
            builder.Property(x => x.Date).HasColumnName("Date");
            builder.Property(x => x.Status).HasColumnName("Status");
            builder.Property(x => x.Title).HasColumnName("Title");
            builder.Property(x => x.UserName).HasColumnName("UserName");

            builder.ToTable("Comments");
        }
    }
}
