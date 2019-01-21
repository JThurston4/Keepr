using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int Views { get; set; }
    //
    public int Saves { get; set; }
    [Required]
    public string Img { get; set; }
    public int Shares { get; set; }
    // [Required]
    public string UserId { get; set; }
    public bool Secret { get; set; }
    public List<Comment> Comments { get; set; }
    public string description { get; set; }
  }
}