using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiMySQL.Models;

namespace ApiMySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WpPostsController : ControllerBase
    {
        private readonly blazordbContext _context;

        public WpPostsController(blazordbContext context)
        {
            _context = context;
        }

        // GET: api/WpPosts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WpPost>>> GetWpPosts()
        {
            /// ユーザー名もリンクして返す
            var q = from post in _context.WpPosts
                    join user in _context.WpUsers on post.post_author equals user.id
                    select new { post, user };
            var items = await q.ToListAsync();
            items.ForEach(t => t.post.User = t.user);
            return items.Select(t => t.post).ToList();
        }

        // GET: api/WpPosts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WpPost>> GetWpPost(int id)
        {
            var wpPost = await _context.WpPosts.FindAsync(id);

            if (wpPost == null)
            {
                return NotFound();
            }
            wpPost.User = _context.WpUsers.FirstOrDefault(t => t.id == wpPost.post_author);
            return wpPost;
        }


        // PUT: api/WpPosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWpPost(int id, WpPost wpPost)
        {
            if (id != wpPost.id)
            {
                return BadRequest();
            }

            _context.Entry(wpPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WpPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/WpPosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WpPost>> PostWpPost(WpPost wpPost)
        {
            _context.WpPosts.Add(wpPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWpPost", new { id = wpPost.id }, wpPost);
        }

        // DELETE: api/WpPosts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWpPost(int id)
        {
            var wpPost = await _context.WpPosts.FindAsync(id);
            if (wpPost == null)
            {
                return NotFound();
            }

            _context.WpPosts.Remove(wpPost);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WpPostExists(int id)
        {
            return _context.WpPosts.Any(e => e.id == id);
        }
    }
}
