namespace TCIT_API.Models
{
  public class Post
  {
    public long Id { get; set; }
    required public string Nombre { get; set; }
    required public string Descripcion { get; set; }
  }
}
