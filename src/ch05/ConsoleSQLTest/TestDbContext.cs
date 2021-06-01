using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSQLTest
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }
        public DbSet<WpPost> WpPosts { get; set; }
        public DbSet<WpUser> WpUsers { get; set; }
        // データ取得のため
        public DbSet<WpPostByUser> WpPostByUsers { get; set; }
        public DbSet<WpUserPostCount> WpUserPostCounts { get; set; }
    }

    [Table("wp_posts")]
    public partial class WpPost
    {
        public int id { get; set; }
        public int post_author { get; set; }
        public DateTime post_date { get; set; }
        public DateTime post_date_gmt { get; set; }
        public string post_content { get; set; }
        public string post_title { get; set; }
        public string post_excerpt { get; set; }
        public string post_status { get; set; }
        public string comment_status { get; set; }
        public string ping_status { get; set; }
        public string post_password { get; set; }
        public string post_name { get; set; }
        public string to_ping { get; set; }
        public string pinged { get; set; }
        public DateTime post_modified { get; set; }
        public DateTime post_modified_gmt { get; set; }
        public string post_content_filtered { get; set; }
        public int post_parent { get; set; }
        public string guid { get; set; }
        public int menu_order { get; set; }
        public string post_type { get; set; }
        public string post_mime_type { get; set; }
        public int comment_count { get; set; }
        [NotMapped]
        public WpUser User { get; set; }
    }

    [Table("wp_users")]
    public partial class WpUser
    {
        public int id { get; set; }
        public string user_login { get; set; }
        public string user_pass { get; set; }
        public string user_nicename { get; set; }
        public string user_email { get; set; }
        public string user_url { get; set; }
        public DateTime user_registered { get; set; }
        public string user_activation_key { get; set; }
        public int user_status { get; set; }
        public string display_name { get; set; }
    }

    public partial class WpPostByUser
    {
        public int id { get; set; }
        public string post_content { get; set; }
        public string post_title { get; set; }
        public int user_id { get; set; }
        public string user_login { get; set; }
    }
    public partial class WpUserPostCount
    {
        public int id { get; set; }
        public string user_login { get; set; }
        public int cnt { get; set; }
    }

}
