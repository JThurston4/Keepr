using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepController : ControllerBase
  {
    private readonly KeepRepository _keepRepo;
    public KeepController(KeepRepository repo)
    {
      _keepRepo = repo;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      return Ok(_keepRepo.GetAll());
    }

    //GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      Keep result = _keepRepo.GetKeepById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetKeeps()
    {
      string userId = HttpContext.User.Identity.Name;
      var result = _keepRepo.GetKeepByUserId(userId);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // // POST api/values
    [HttpPost]
    public Keep Post([FromBody] Keep value)
    {
      value.UserId = HttpContext.User.Identity.Name;
      _keepRepo.AddKeep(value);
      return value;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep value)
    {
      if (value.Id == 0)
      {
        value.Id = id;
      }
      Keep result = _keepRepo.EditKeep(id, value);
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
      if (_keepRepo.DeleteKeep(id))
      {
        return "deleted keep";
      }
      return "cant delte";
    }

  }
}