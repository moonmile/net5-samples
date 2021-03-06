using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Sqlite;


#nullable disable

namespace ApiSQLite.Models
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

        public virtual DbSet<WpPost> WpPosts { get; set; }
        public virtual DbSet<WpUser> WpUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseMySQL("server=localhost;user id=wpuser;persistsecurityinfo=True;database=wpdb");
                // optionsBuilder.UseSqlite("");
            }
        }
    }
}
