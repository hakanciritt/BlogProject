using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ObjectMappings
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(c => c.AdminId);
            builder.Property(c => c.AdminId).UseIdentityColumn();

            builder.ToTable("Admins");
        }
    }
}
