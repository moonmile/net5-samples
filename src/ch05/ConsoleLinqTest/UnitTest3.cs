using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConsoleLinqTest
{
    public class UnitTestSample
    {
        TestDbContext _context;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public UnitTestSample()
        {
            var builder = new DbContextOptionsBuilder<TestDbContext>();
            builder.UseInMemoryDatabase("memory");
            builder.EnableServiceProviderCaching(false);
            _context = new TestDbContext(builder.Options);

            /// 初期データ
            _context.WpUsers.AddRange(new WpUser[]
            {
                new WpUser(){ Id = 100, UserLogin = "masuda" },
                new WpUser(){ Id = 101, UserLogin = "tomoaki" },
                new WpUser(){ Id = 102, UserLogin = "yamada" },
                new WpUser() { Id =  103, UserLogin =  "aoki" },
            });

            _context.WpPosts.AddRange(new WpPost[]
            {
                new WpPost() { Id = 1, PostAuthor =  100, PostTitle = "はじめての記事" },
                new WpPost() { Id = 2, PostAuthor =  100, PostTitle =  "二番目の記事" },
                new WpPost() { Id = 3, PostAuthor =  100, PostTitle =  "三番目の記事" },
                new WpPost() { Id = 4, PostAuthor =  101, PostTitle = "はじめての記事" },
                new WpPost() { Id = 5, PostAuthor = 101,  PostTitle = ".NET5について" },
                new WpPost() { Id = 6, PostAuthor = 102, PostTitle =  "はじめての記事" },
                new WpPost() { Id = 7, PostAuthor = 102, PostTitle = "C#について" } ,
                new WpPost() { Id = 8, PostAuthor = 102, PostTitle = "F#について" },
                new WpPost() { Id = 9, PostAuthor =  100, PostTitle =  "最後の記事" },
            });
            _context.SaveChanges();
        }

        /// ユーザーの一覧を取得
        [Fact]
public void Test1()
{
    // 一覧を取得
    var lst = _context.WpUsers.ToList();
    Assert.Equal(4, lst.Count);
    Assert.Equal(100, lst.First().Id);
    Assert.Equal("masuda", lst.First().UserLogin);
}
        /// 記事の一覧を取得
        [Fact]
        public void Test2()
{
    // 一覧を取得
    var lst = _context.WpPosts.ToList();

    Assert.Equal(9, lst.Count);
    Assert.Equal(1, lst.First().Id);
    Assert.Equal(100, lst.First().PostAuthor);
    Assert.Equal("はじめての記事", lst.First().PostTitle);
}
        /// 記事の一覧を取得（ユーザー付）
        [Fact]
        public void Test3()
        {
            var query =
                from user in _context.WpUsers
                join post in _context.WpPosts on user.Id equals post.PostAuthor
                select new { Post = post, User = user };
            var lst = query.ToList();

            Assert.Equal(9, lst.Count);
            Assert.Equal(1, lst.First().Post.Id);
            Assert.Equal("はじめての記事", lst.First().Post.PostTitle);
            Assert.Equal("masuda", lst.First().User.UserLogin);
        }
        /// yamadaさんの記事を取得
        [Fact]
public void Test4()
{
    var name = "yamada";
    var query =
        from user in _context.WpUsers
        join post in _context.WpPosts on user.Id equals post.PostAuthor
        where user.UserLogin == name
        select new { Post = post, User = user };
    var lst = query.ToList();

    Assert.Equal(3, lst.Count);
    Assert.Equal(6, lst.First().Post.Id);
    Assert.Equal("はじめての記事", lst.First().Post.PostTitle);
    Assert.Equal("yamada", lst.First().User.UserLogin);
}
        /// 「について」を含む記事を取得
        [Fact]
        public void Test5()
        {
            // 一覧を取得
            var lst = _context.WpPosts
                .Where(t => t.PostTitle.Contains("について"))
                .ToList();

            Assert.Equal(3, lst.Count);
        }

        /// ユーザーをソート
        [Fact]
        public void Test6()
        {
            var lst = _context.WpUsers
                .OrderBy(t => t.UserLogin)
                .ToList();

            Assert.Equal("aoki", lst.First().UserLogin);
        }
        /// ソートの最後を取得
        [Fact]
        public void Test7()
        {
            var item = _context.WpUsers
                .OrderBy(t => t.UserLogin)
                .Last();

            Assert.Equal("yamada", item.UserLogin);
        }
        /// 投稿していない人を取得
        [Fact]
        public void Test8()
        {
            var query =
                from user in _context.WpUsers
                join post in _context.WpPosts on user.Id equals post.PostAuthor into g
                from subpost in g.DefaultIfEmpty()
                where subpost == null
                select user;
            var lst = query.ToList();
            Assert.Equal(1, lst.Count);
            Assert.Equal("aoki", lst.First().UserLogin);
        }
        /// 投稿している数順で取得
        [Fact]
        public void Test9()
        {
            var query =
                from user in _context.WpUsers
                join post in _context.WpPosts on user.Id equals post.PostAuthor
                select new { User = user, Post = post };
            var lst =
                query.ToList()
                .GroupBy(t => t.User)
                .Select(t => new { User = t.Key, Count = t.Count() })
                .OrderByDescending(t => t.Count)
                .ToList();

            Assert.Equal(3, lst.Count);
            Assert.Equal("masuda", lst.First().User.UserLogin);
        }
    }
}
