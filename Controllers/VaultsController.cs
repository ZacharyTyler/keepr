using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _ks;
    public VaultsController(VaultsService ks)
    {
      _ks = ks;
    }
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        string UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.Get(UserId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
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
    public ActionResult<Vault> Create([FromBody] Vault newVault)
    {
      try
      {
        newVault.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.Create(newVault));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Vault> Delete(int id)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.Delete(id, userId));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}