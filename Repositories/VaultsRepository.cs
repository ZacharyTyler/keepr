using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Vault> Get(string userId)
    {

      string sql = "SELECT * FROM vaults WHERE UserId = @userId";
      return _db.Query<Vault>(sql, new { userId });
    }

    public int Create(Vault newVault)
    {
      string sql = @"
            INSERT INTO vaults
            (id, name, description, userId)
            VALUES
            (@Id, @Name, @Description, @UserId);";
      return _db.Execute(sql, newVault);
    }

    public Vault Get(int id)
    {
      string sql = "SELECT * FROM vaults WHERE Id = @id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }
    public void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE Id = @id";
      _db.Execute(sql, new { id });
    }
  }
}