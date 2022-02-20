using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ObjectMappings
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasKey(x => x.AboutId);
            builder.Property(x => x.AboutId).HasColumnType("int");
            builder.Property(x => x.AboutId).HasColumnType("int");
            builder.Property(x => x.Details1).HasColumnType("varchar(max)");
            builder.Property(x => x.Details2).HasColumnType("varchar(max)");
            builder.Property(x => x.Image1).HasColumnType("varchar(200)");
            builder.Property(x => x.Image2).HasColumnType("varchar(200)");
            builder.Property(x => x.MapLocation).HasColumnType("varchar(max)");
            builder.Property(x => x.Status).HasColumnType("bit");


            builder.Property(x => x.AboutId).HasColumnName("AboutId");
            builder.Property(x => x.Details1).HasColumnName("Details1");
            builder.Property(x => x.Details2).HasColumnName("Details2");
            builder.Property(x => x.Image1).HasColumnName("Image1");
            builder.Property(x => x.Image2).HasColumnName("Image2");
            builder.Property(x => x.MapLocation).HasColumnName("MapLocation");
            builder.Property(x => x.Status).HasColumnName("Status");

            builder.ToTable("Abouts");
        }
    }
}
