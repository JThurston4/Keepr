using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;

    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM Keeps WHERE isPrivate = false");
    }

    public Keep AddKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
 	      INSERT INTO keeps (Name, Description, Img, UserId, isPrivate) Values(@Name, @Description, @Img, @UserId, @Secret);
 	      SELECT LAST_INSERT_ID();", newKeep);
      newKeep.Id = id;
      return newKeep;
    }
    public Keep GetKeepById(int id)
    {
      try
      {
        return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keeps WHERE id = @id", new { id });
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex);
        return null;
      }

    }

    public IEnumerable<Keep> GetKeepByUserId(string userId)
    {
      try
      {
        return _db.Query<Keep>($"SELECT * FROM Keeps WHERE userId = @userId", new { userId });
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex);
        return null;
      }

    }


    //edit needs work
    public Keep EditKeep(int id, Keep newKeep)
    {
      try
      {
        return _db.QueryFirstOrDefault<Keep>($@"
          UPDATE Keeps SET
            Name = @Name,
            Description = @Description,
            Price = @Price
          WHERE Id = @Id;
          SELECT * FROM Keeps WHERE id = @Id;
        ", newKeep);
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex);
        return null;
      }
    }
    //edit needs work
    public bool DeleteKeep(int id)
    {
      int success = _db.Execute("DELETE FROM Keeps WHERE id = @id", new { id });
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