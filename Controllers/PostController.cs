using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCIT_API.Data;
using TCIT_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TCIT_API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostController : ControllerBase
  {
    private readonly PostContext _context;

    public PostController(PostContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
    {
      var posts = await _context.Posts.ToListAsync();
      return Ok(posts);
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
      _context.Posts.Add(post);
      await _context.SaveChangesAsync();

      return StatusCode(201, post);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(long id)
    {
      var post = await _context.Posts.FindAsync(id);

      if (post == null)
      {
        return NotFound();
      }

      _context.Posts.Remove(post);
      await _context.SaveChangesAsync();

      return Ok(post);
    }

  }
}