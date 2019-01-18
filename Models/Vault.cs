namespace keepr.Models
{
  public class Vault
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Secret { get; set; }
    public string UserId { get; set; }
    public string Image { get; set; }
    public int Followers { get; set; }
  }
}