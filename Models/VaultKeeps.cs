namespace keepr.Models
{
  public class VaultKeeps
  {
    public int id { get; set; }
    public int VaultId { get; set; }
    public int KeepId { get; set; }
    public string UserId { get; set; }
  }
}