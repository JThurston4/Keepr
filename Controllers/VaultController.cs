using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultController : ControllerBase
  {
    private readonly VaultRepository _vaultRepo;
    public VaultController(VaultRepository repo)
    {
      _vaultRepo = repo;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return Ok(_vaultRepo.GetAll());
    }

    //GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      Vault result = _vaultRepo.GetVaultById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // // POST api/values
    [HttpPost]
    public Vault Post([FromBody] Vault value)
    {
      value.UserId = HttpContext.User.Identity.Name;
      _vaultRepo.AddVault(value);
      return value;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Vault> Put(int id, [FromBody] Vault value)
    {
      if (value.Id == 0)
      {
        value.Id = id;
      }
      Vault result = _vaultRepo.EditVault(id, value);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }

    // // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      if (_vaultRepo.DeleteVault(id))
      {
        return "deleted Vault";
      }
      return "cant delte";
    }

  }
}