using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Vault> GetAll()
    {
      return _db.Query<Vault>("SELECT * FROM Vaults");
    }

    public Vault AddVault(Vault newVault)
    {
      int id = _db.ExecuteScalar<int>(@"
 	      INSERT INTO vaults (Name, Description, Img, UserId, isPrivate) Values(@Name, @Description, @Img, @UserId, @Secret);
 	      SELECT LAST_INSERT_ID();", newVault);
      newVault.Id = id;
      return newVault;
    }
    public Vault GetVaultById(int id)
    {
      try
      {
        return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM Vaults WHERE id = @id", new { id });
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex);
        return null;
      }

    }
    public IEnumerable<Vault> GetVaultByUserId(string userId)
    {
      try
      {
        return _db.Query<Vault>($"SELECT * FROM Vaults WHERE userId = @userId", new { userId });
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex);
        return null;
      }

    }


    //edit needs work
    public Vault EditVault(int id, Vault newVault)
    {
      try
      {
        return _db.QueryFirstOrDefault<Vault>($@"
          UPDATE Vaults SET
            Name = @Name,
            Description = @Description,
            Price = @Price
          WHERE Id = @Id;
          SELECT * FROM Vaults WHERE id = @Id;
        ", newVault);
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex);
        return null;
      }
    }
    //edit needs work
    public bool DeleteVault(int id)
    {
      int success = _db.Execute("DELETE FROM Vaults WHERE id = @id", new { id });
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