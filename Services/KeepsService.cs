using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {

      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    public Keep Create(Keep newKeep)
    {
      int id = _repo.Create(newKeep);
      newKeep.Id = id;
      return newKeep;
    }

    public Keep Get(int id)
    {
      Keep exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }

    public IEnumerable<Keep> GetKeepsByUser(string UserId)
    {
      return _repo.GetKeepsByUser(UserId);


    }

    public Keep Edit(Keep newKeep)
    {
      Keep keep = _repo.Get(newKeep.Id);
      if (keep == null) { throw new Exception("Invalid Id"); }
      keep.Views = newKeep.Views;
      keep.Keeps = newKeep.Keeps;
      _repo.Edit(keep);
      return keep;
    }

    public string Delete(int id, string userId)
    {
      Keep keep = _repo.Get(id);
      if (keep == null || keep.UserId != userId) { throw new Exception("Invalid Request"); }
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}