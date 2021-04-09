using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace mvcsqlserver.Models
{
    public partial class blazordbContext : DbContext
    {
        public blazordbContext()
        {
        }

        public blazordbContext(DbContextOptions<blazordbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=blazordb;Trusted_connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Japanese_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("author");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Publisher)
                    .HasMaxLength(50)
                    .HasColumnName("publisher");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("title");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
