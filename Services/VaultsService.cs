using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {

      _repo = repo;
    }
    public IEnumerable<Vault> Get()
    {
      return _repo.Get();
    }

    public Vault Create(Vault newVault)
    {
      int id = _repo.Create(newVault);
      newVault.Id = id;
      return newVault;
    }

    public Vault Get(int id)
    {
      Vault exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid ID"); }
      return exists;
    }

    public string Delete(int id, string userId)
    {
      Vault vault = _repo.Get(id);
      if (vault == null || vault.UserId != userId) { throw new Exception("Invalid Request"); }
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}