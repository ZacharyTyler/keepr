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

    public IEnumerable<VaultKeep> Get(int vaultId)
    {
      string sql = "SELECT * FROM vaultKeeps WHERE VaultId = @vaultId";
      return _db.Query<VaultKeep>(sql, new { vaultId });
    }
    public IEnumerable<Keep> GetKeepByVaultId(int vaultId, string userId)
    {
      string sql = @"
                     SELECT * FROM vaultkeeps vk
                     INNER JOIN keeps k ON k.id = vk.keepId 
                     WHERE (vaultId = @vaultId AND vk.userId = @userId)";
      return _db.Query<Keep>(sql, new { vaultId, userId });
    }

    public void Edit(VaultKeep vaultKeep)
    {

      string sql = "DELETE FROM vaultKeeps WHERE KeepId = @KeepId AND VaultId = @VaultId";
      _db.Execute(sql, vaultKeep);
    }

  }
}