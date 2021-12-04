using DataAccess.ObjectMappings;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Concrete
{
    public class BlogContext : DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Natification> Natifications { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = (IConfiguration)ServiceTool.ServiceProvider.GetService(typeof(IConfiguration));
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:SqlConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new AboutConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new WriterConfiguration());
            modelBuilder.ApplyConfiguration(new NatificationConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());

            modelBuilder.Entity<Blog>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.Blog)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.BlogId);

            modelBuilder.Entity<Blog>()
                .HasOne(x => x.Writer)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.WriterId);
        }
    }
}
