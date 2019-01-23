using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepController : ControllerBase
  {
    private readonly VaultKeepRepository _vaultKeepRepo;
    public VaultKeepController(VaultKeepRepository repo)
    {
      _vaultKeepRepo = repo;
    }

    // GET api/values
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> Get(int id)
    {
      string userId = HttpContext.User.Identity.Name;
      var result = _vaultKeepRepo.GetVaultKeeps(id, userId);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }


    //GET api/values/5
    // [HttpGet("{id}")]
    // public ActionResult<VaultKeep> Get(int id)
    // {
    //   VaultKeep result = _vaultKeepRepo.GetVaultKeepById(id);
    //   if (result != null)
    //   {
    //     return Ok(result);
    //   }
    //   return BadRequest();
    // }

    // POST api/values
    [HttpPost]
    public VaultKeep Post([FromBody] VaultKeep value)
    {
      value.UserId = HttpContext.User.Identity.Name;
      _vaultKeepRepo.AddVaultKeep(value);
      return value;
    }

    // PUT api/values/5
    // [HttpPut("{id}")]
    // public ActionResult<VaultKeep> Put(int id, [FromBody] VaultKeep value)
    // {
    //   if (value.Id == 0)
    //   {
    //     value.Id = id;
    //   }
    //   VaultKeep result = _vaultKeepRepo.EditVaultKeep(id, value);
    //   if (result != null)
    //   {
    //     return Ok(result);
    //   }
    //   return NotFound();
    // }

    // // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(VaultKeep value)
    {
      if (_vaultKeepRepo.DeleteVaultKeep(value))
      {
        return "deleted VaultKeep";
      }
      return "cant delte";
    }

  }
}