using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _ks;
    public VaultKeepsController(VaultKeepsService ks)
    {
      _ks = ks;
    }

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<VaultKeep>> Get(int id)
    {
      try
      {
        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        newVaultKeep.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.Create(newVaultKeep));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPut]
    public ActionResult<VaultKeep> Edit([FromBody] VaultKeep newVaultKeep, int id)
    {
      try
      {
        newVaultKeep.Id = id;
        return Ok(_ks.Edit(newVaultKeep));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

  }
}