using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using System.Data.Entity.Core.Objects;

namespace ConsoleSQLTest
{
    public class UnitTestSQL 
    {
        TestDbContext _context;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UnitTestSQL()
        {
            var builder = new DbContextOptionsBuilder<TestDbContext>();
            builder.UseSqlServer("Server=.;Database=blazordb;Trusted_connection=True");
            builder.EnableServiceProviderCaching(false);
            _context = new TestDbContext(builder.Options);
        }

        /// <summary>
        /// ユーザーの一覧を取得
        /// </summary>
        [Fact]
        public void Test1()
        {
            var lst =
                _context.WpUsers.FromSqlRaw(
                    "select * from wp_users")
                .ToList();
            Assert.NotEmpty(lst);
        }

        /// 記事の一覧を取得（ユーザー付）
        [Fact]
        public void Test3()
        {
            var SQL = @"
select 
	wp_posts.id,
	wp_posts.post_title,
	wp_posts.post_content,
    wp_users.ID as user_id,
    wp_users.user_login
from wp_posts 
  inner join wp_users on wp_posts.post_author = wp_users.ID
";
            var lst =
                _context.WpPostByUsers
                .FromSqlRaw(SQL)
                .ToList();
            Assert.NotEmpty(lst);
        }

        /// yamadaさんの記事を取得
[Fact]
public void Test4()
{
    var name = "yamada";
    FormattableString SQL = $@"
select 
wp_posts.*
from wp_posts 
inner join wp_users on wp_posts.post_author = wp_users.ID
where wp_users.user_login = '{name}'
";
    var lst =
    _context.WpPosts
    .FromSqlInterpolated(SQL)
    .ToList();
    Assert.NotEmpty(lst);
}

        /// ユーザーをソート
        [Fact]
        public void Test6()
        {
            var SQL = @"
select *
from wp_users
order by user_login
";
            var lst = _context.WpUsers
                .FromSqlRaw(SQL)
                .ToList();
            Assert.NotEmpty(lst);
        }
        /// 投稿していない人を取得
        [Fact]
        public void Test8()
        {
            var SQL = @"
select 
	wp_users.*
from wp_users
 inner join 
( select 
	wp_users.ID
from wp_users
	left join wp_posts on wp_users.ID = wp_posts.post_author
group by wp_users.ID
having count(wp_posts.ID) = 0 ) x on wp_users.ID = x.ID
";
            var lst = _context.WpUsers
                .FromSqlRaw(SQL)
                .ToList();
            Assert.NotEmpty(lst);
        }

        /// 投稿している数順で取得
        [Fact]
        public void Test9()
        {
            var SQL = @"
select 
	wp_users.ID
,	wp_users.user_login
,	count(wp_posts.ID) cnt
from wp_users
	left join wp_posts on wp_users.ID = wp_posts.post_author
group by wp_users.ID, wp_users.user_login
order by cnt desc
";
            var lst = _context.WpUserPostCounts
                .FromSqlRaw(SQL)
                .ToList();
            Assert.NotEmpty(lst);
        }
    }
}
