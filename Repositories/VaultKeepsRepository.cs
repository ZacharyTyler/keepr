using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public int Create(VaultKeep newVaultKeep)
    {
      string sql = @"
            INSERT INTO vaultKeeps
            (vaultId, keepId, userId)
            VALUES
            (@VaultId, @KeepId, @UserId);
            SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVaultKeep);
    }

    public IEnumerable<VaultKeep> Get(int id)
    {
      string sql = "SELECT * FROM vaultKeeps WHERE VaultId = @id";
      return _db.Query<VaultKeep>(sql, new { id });
    }

    public void Edit(VaultKeep vaultKeep)
    {
      string sql = @"
            UPDATE vaultKeeps
            SET
                vaultId = @VaultId,
                keepId = @KeepId,
                userId = @UserId
            WHERE id = @Id";
      _db.Execute(sql, vaultKeep);
    }

  }
}