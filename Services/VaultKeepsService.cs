using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {

      _repo = repo;
    }

    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      int id = _repo.Create(newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }

    public IEnumerable<VaultKeep> Get(int id)
    {
      return _repo.Get(id);

    }

    public VaultKeep Edit(VaultKeep newVaultKeep)
    {
      IEnumerable<VaultKeep> vaultKeep = _repo.Get(newVaultKeep.Id);
      if (vaultKeep == null) { throw new Exception("Invalid Id"); }

      _repo.Edit(newVaultKeep);
      return newVaultKeep;
    }

  }
}