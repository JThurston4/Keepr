namespace keepr.Repositories
{
  public class KeeprRepository
  {
    private readonly IDbConnection _db;

    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Burger> GetAll()
    {
      return _db.Query<Burger>("SELECT * FROM Burgers");
    }

    public Burger AddBurger(Burger newBurger)
    {
      int id = _db.ExecuteScalar<int>(@"
 	      INSERT INTO Burgers (Name, Description, Price) Values(@Name, @Description, @Price);
 	      SELECT LAST_INSERT_ID();", newBurger);
      newBurger.Id = id;
      return newBurger;
    }
    public Burger GetBurgerById(int id)
    {
      try
      {
        return _db.QueryFirstOrDefault<Burger>($"SELECT * FROM Burgers WHERE id = @id", new { id });
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex);
        return null;
      }

    }
    public Burger EditBurger(int id, Burger newBurger)
    {
      try
      {
        return _db.QueryFirstOrDefault<Burger>($@"
          UPDATE burgers SET
            Name = @Name,
            Description = @Description,
            Price = @Price
          WHERE Id = @Id;
          SELECT * FROM burgers WHERE id = @Id;
        ", newBurger);
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex);
        return null;
      }
    }
    public bool DeleteBurger(int id)
    {
      int success = _db.Execute("DELETE FROM Burgers WHERE id = @id", new { id });
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