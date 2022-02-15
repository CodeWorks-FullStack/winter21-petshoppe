using Microsoft.AspNetCore.Mvc;
using petshop.Models;
using petshop.Services;

namespace petshop.Controllers
// NOTE if an error won't go away but you are convinced it's wrong, re-spin the server or restart vs-code
{
  [ApiController]
  // NOTE below is basically the 'super' of the application - we are dictating what the api route looks like

  // NOTE "api/[controller]" will pull off the name of the controller up to the word controller, and use that as the route name
  [Route("api/[controller]")]
  public class CatsController : ControllerBase
  {
    private readonly CatsService _cs;
    public CatsController(CatsService cs)
    {
      _cs = cs;
    }

    [HttpGet]

    // NOTE this is our get all - think .get('', this.getAll)
    public ActionResult<List<Cat>> GetAll()
    {
      try
      {
        return Ok(_cs.GetAll());
        //  NOTE return Ok is the C# equivalent of res.send
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{catId}")]
    // NOTE this is our get by ID - think .get('/:id', this.getById)
    // NOTE the "{id}" is our route param

    public ActionResult<Cat> GetById(string catId)
    {
      try
      {
        // Cat is the type this variable is, foundCat is the variable name
        Cat foundCat = _cs.GetById(catId);
        return Ok(foundCat);

        // NOTE same as above, just all in one line
        // return Ok(_cs.GetById(catId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]

    // NOTE [FromBody] == req.body, then we dictate the type of data coming in, then the variable name
    public ActionResult<Cat> Create([FromBody] Cat newCat)
    {
      try
      {
        return Ok(_cs.Create(newCat));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{catId}")]

    public ActionResult<Cat> Delete(string catId)
    {
      try
      {
        return Ok(_cs.Delete(catId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{catId}")]

    public ActionResult<Cat> Edit([FromBody] Cat editedCat, string catId)
    {
      try
      {
        // NOTE not allowing the user to send up a different id - pulling id off of the "route params"
        editedCat.Id = catId;
        Cat updatedCat = _cs.Edit(editedCat, catId);
        return Ok(updatedCat);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}