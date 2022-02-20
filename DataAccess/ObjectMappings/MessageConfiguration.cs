using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.ObjectMappings
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.MessageId);
            builder.Property(x => x.MessageId).HasColumnType("int");
            builder.Property(x => x.Type).HasColumnType("bit");
            builder.Property(x => x.Details).HasColumnType("varchar(max)");
            builder.Property(x => x.Date).HasColumnType("Datetime");
            builder.Property(x => x.Receiver).HasColumnType("varchar(100)");
            builder.Property(x => x.Sender).HasColumnType("varchar(100)");
            builder.Property(x => x.Subject).HasColumnType("varchar(150)");

            builder.Property(x => x.MessageId).HasColumnName("MessageId");
            builder.Property(x => x.Type).HasColumnName("Type");
            builder.Property(x => x.Details).HasColumnName("Details");
            builder.Property(x => x.Date).HasColumnName("Date");
            builder.Property(x => x.Receiver).HasColumnName("Receiver");
            builder.Property(x => x.Sender).HasColumnName("Sender");
            builder.Property(x => x.Subject).HasColumnName("Subject");


            builder.ToTable("Messages");
        }
    }
}
