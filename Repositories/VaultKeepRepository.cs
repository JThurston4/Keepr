using System;
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
    public IEnumerable<VaultKeep> GetAll()
    {
      return _db.Query<VaultKeep>("SELECT * FROM VaultKeeps");
    }

    public VaultKeep AddVaultKeep(VaultKeep newVaultKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaultkeeps (VaultId, KeepId, UserId) Values(@VaultId, @KeepId, @UserId);
        SELECT LAST_INSERT_ID();", newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }
    public VaultKeep GetVaultKeepById(int id)
    {
      try
      {
        return _db.QueryFirstOrDefault<VaultKeep>($"SELECT * FROM VaultKeeps WHERE id = @id", new { id });
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex);
        return null;
      }

    }


    //edit needs work
    // public VaultKeep EditVaultKeep(int id, VaultKeep newVaultKeep)
    // {
    //   try
    //   {
    //     return _db.QueryFirstOrDefault<VaultKeep>($@"
    //       UPDATE VaultKeeps SET
    //         Name = @Name,
    //         Description = @Description,
    //         Price = @Price
    //       WHERE Id = @Id;
    //       SELECT * FROM VaultKeeps WHERE id = @Id;
    //     ", newVaultKeep);
    //   }
    //   catch (Exception ex)
    //   {
    //     System.Console.WriteLine(ex);
    //     return null;
    //   }
    // }
    //edit needs work
    public bool DeleteVaultKeep(int id)
    {
      int success = _db.Execute("DELETE FROM VaultKeeps WHERE id = @id", new { id });
      if (success == 0)
      {
        return false;
      }
      else
      {
        return true;
      }
    }
  }
}