using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCIT_API.Data;
using TCIT_API.Models;

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
      try
      {
        var posts = await _context.Posts.ToListAsync();
        return Ok(posts);
      }
      catch (Exception ex)
      {
        return StatusCode(500, "Internal server error");
      }
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost(Post post)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return BadRequest(ModelState);
        }

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return StatusCode(201, post);
      }
      catch (DbUpdateException dbEx)
      {
        return StatusCode(500, "A database error occurred");
      }
      catch (Exception ex)
      {
        return StatusCode(500, "Internal server error");
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(long id)
    {
      try
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
      catch (DbUpdateException dbEx)
      {
        return StatusCode(500, "A database error occurred");
      }
      catch (Exception ex)
      {
        return StatusCode(500, "Internal server error");
      }
    }

  }
}