using System.ComponentModel.DataAnnotations;

namespace TCIT_API.Models
{
  public class Post
  {
    public long Id { get; set; }

    [Required(ErrorMessage = "El Nombre debe ser proporcionado")]
    required public string Nombre { get; set; }
    required public string Descripcion { get; set; }
  }
}