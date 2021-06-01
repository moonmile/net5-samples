using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLinqTest
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }
        public DbSet<WpPost> WpPosts { get; set; }
        public DbSet<WpUser> WpUsers { get; set; }
    }

    public partial class WpPost
    {
        public int Id { get; set; }
        public int PostAuthor { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime PostDateGmt { get; set; }
        public string PostContent { get; set; }
        public string PostTitle { get; set; }
        public string PostExcerpt { get; set; }
        public string PostStatus { get; set; }
        public string CommentStatus { get; set; }
        public string PingStatus { get; set; }
        public string PostPassword { get; set; }
        public string PostName { get; set; }
        public string ToPing { get; set; }
        public string Pinged { get; set; }
        public DateTime PostModified { get; set; }
        public DateTime PostModifiedGmt { get; set; }
        public string PostContentFiltered { get; set; }
        public int PostParent { get; set; }
        public string Guid { get; set; }
        public int MenuOrder { get; set; }
        public string PostType { get; set; }
        public string PostMimeType { get; set; }
        public int CommentCount { get; set; }
        [NotMapped]
        public WpUser User { get; set; }
    }
    /*
    public partial class WpUser
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        public string UserPass { get; set; }
        public string UserNicename { get; set; }
        public string UserEmail { get; set; }
        public string UserUrl { get; set; }
        public DateTime UserRegistered { get; set; }
        public string UserActivationKey { get; set; }
        public int UserStatus { get; set; }
        public string DisplayName { get; set; }
    }
    */

    [Table("wp_users")]
    public partial class WpUser
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("user_login")]
        public string UserLogin { get; set; }
        [Column("user_pass")]
        public string UserPass { get; set; }
        [Column("user_nickname")]
        public string UserNicename { get; set; }
        [Column("user_email")]
        public string UserEmail { get; set; }
        [Column("user_url")]
        public string UserUrl { get; set; }
        [Column("user_registered")]
        public DateTime UserRegistered { get; set; }
        [Column("user_activation_key")]
        public string UserActivationKey { get; set; }
        [Column("user_status")]
        public int UserStatus { get; set; }
        [Column("display_name")]
        public string DisplayName { get; set; }
    }

}
