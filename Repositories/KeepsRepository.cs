using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM keeps";
      return _db.Query<Keep>(sql);
    }

    public int Create(Keep newKeep)
    {
      string sql = @"
            INSERT INTO keeps
            (id, name, description, userId, img, isPrivate, views, keeps)
            VALUES
            (@Id, @Name, @Description, @UserId, @Img, @IsPrivate, @Views, @Keeps);";
      return _db.Execute(sql, newKeep);
    }

    public IEnumerable<Keep> GetKeepsByUser(string userId)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @userId";
      return _db.Query<Keep>(sql, new { userId });
    }

    public Keep Get(int id)
    {
      string sql = "SELECT * FROM keeps WHERE Id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    public void Edit(Keep keep)
    {
      string sql = @"
            UPDATE keeps
            SET
                name = @Name,
                description = @Description,
                userId = @UserId,
                img = @Img,
                isPrivate = @IsPrivate,
                views = @Views,
                keeps = @Keeps
            WHERE id = @Id";
      _db.Execute(sql, keep);
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE Id = @id";
      _db.Execute(sql, new { id });
    }
  }
}