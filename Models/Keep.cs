using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    [Required]
    public string Name { get; set; }
    public int Views { get; set; }
    public int Saves { get; set; }
    [Required]
    public string Image { get; set; }
    [Required]
    public string UserName { get; set; }
    public List<Comment> Comments { get; set; }
    public string description { get; set; }
  }
}