using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApiSqlServer.Models
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
        public virtual DbSet<WpPost> WpPosts { get; set; }
        public virtual DbSet<WpUser> WpUsers { get; set; }

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

            modelBuilder.Entity<WpPost>(entity =>
            {
                entity.ToTable("wp_posts");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CommentCount)
                    .HasColumnName("comment_count")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CommentStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("comment_status")
                    .HasDefaultValueSql("('open')");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("guid")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.MenuOrder)
                    .HasColumnName("menu_order")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PingStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ping_status")
                    .HasDefaultValueSql("('open')");

                entity.Property(e => e.Pinged)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("pinged");

                entity.Property(e => e.PostAuthor)
                    .HasColumnName("post_author")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostContent)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("post_content");

                entity.Property(e => e.PostContentFiltered)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("post_content_filtered");

                entity.Property(e => e.PostDate)
                    .HasColumnType("datetime")
                    .HasColumnName("post_date")
                    .HasDefaultValueSql("('1980-01-01 00:00:00')");

                entity.Property(e => e.PostDateGmt)
                    .HasColumnType("datetime")
                    .HasColumnName("post_date_gmt")
                    .HasDefaultValueSql("('1980-01-01 00:00:00')");

                entity.Property(e => e.PostExcerpt)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("post_excerpt");

                entity.Property(e => e.PostMimeType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("post_mime_type")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostModified)
                    .HasColumnType("datetime")
                    .HasColumnName("post_modified")
                    .HasDefaultValueSql("('1980-01-01 00:00:00')");

                entity.Property(e => e.PostModifiedGmt)
                    .HasColumnType("datetime")
                    .HasColumnName("post_modified_gmt")
                    .HasDefaultValueSql("('1980-01-01 00:00:00')");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("post_name")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostParent)
                    .HasColumnName("post_parent")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PostPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("post_password")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.PostStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("post_status")
                    .HasDefaultValueSql("('publish')");

                entity.Property(e => e.PostTitle)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("post_title");

                entity.Property(e => e.PostType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("post_type")
                    .HasDefaultValueSql("('post')");

                entity.Property(e => e.ToPing)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("to_ping");
            });

            modelBuilder.Entity<WpUser>(entity =>
            {
                entity.ToTable("wp_users");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("display_name")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserActivationKey)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_activation_key")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_email")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserLogin)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("user_login")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserNicename)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_nicename")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserPass)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("user_pass")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.UserRegistered)
                    .HasColumnType("datetime")
                    .HasColumnName("user_registered")
                    .HasDefaultValueSql("('1980-01-01')");

                entity.Property(e => e.UserStatus)
                    .HasColumnName("user_status")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.UserUrl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_url")
                    .HasDefaultValueSql("('')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
