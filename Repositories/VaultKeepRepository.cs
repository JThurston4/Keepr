using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;

    }



    //GetVaultKeeps
    //Searching by vaultId and looking for all keeps with that vault id
    public IEnumerable<Keep> GetVaultKeeps(int vaultId, string userId)
    {
      return _db.Query<Keep>($@"
        SELECT * FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId
        WHERE (vk.vaultId = @vaultId AND vk.userId = @userId) 
      ", new { vaultId, userId });
      // WHERE (keepId = @id AND vk.userId = @UserId) 
    }


    //AddVaultKeep
    public VaultKeep AddVaultKeep(VaultKeep vk)
    {
      int id = _db.ExecuteScalar<int>(@"
      INSERT INTO vaultkeeps(vaultId, keepId, userId)
      VALUES(@VaultId, @KeepId, @UserId);
      SELECT LAST_INSERT_ID();
      ", vk);
      vk.Id = id;
      return vk;
    }

    //DeleteVaultKeep

    public bool DeleteVaultKeep(VaultKeep vk)
    {
      int success = _db.Execute(@"DELETE FROM vaultkeeps WHERE keepId = @KeepId AND vaultId = @vaultId", vk);
      return success != 0;

    }
  }
}