using Microsoft.EntityFrameworkCore;
using TCIT_API.Models;

namespace TCIT_API.Data
{
  public class PostContext : DbContext
  {
    public PostContext(DbContextOptions<PostContext> options) : base(options) { }

    public DbSet<Post> Posts { get; set; }
  }
}
