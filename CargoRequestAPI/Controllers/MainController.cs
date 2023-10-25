using CargoRequestAPI.Data;
using CargoRequestAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CargoRequestAPI.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MainController : ControllerBase
{
    private ICargoRequestRepository _cargoRepo;

    public MainController(ICargoRequestRepository cargoRepo) {
        _cargoRepo = cargoRepo;
    }

    [HttpGet(Name = "GetAllCargoRequests")]
    public async Task<ActionResult<IEnumerable<CargoRequest>>> GetAllCargoRequests() 
    {
        var requests = await _cargoRepo.GetCargoRequests();
        return Ok(requests);
    }


    [HttpGet("{idCargoRequest:int}", Name = "GetCargoRequest")]
    public async Task<ActionResult<CargoRequest>> GetCargoRequest(int idCargoRequest)
    {
        var requests = await _cargoRepo.GetById(idCargoRequest);
        if (requests == null) 
        {
            return NotFound();
        }
        return Ok(requests);
    }


    [HttpPost(Name = "AddCargoRequest")]
    public async Task<ActionResult> AddCargoRequest(CargoRequest req) 
    {
        if (ModelState.IsValid)
        {
            await _cargoRepo.Create(req);
            return Ok(new { message = "Cargo Request created" });
        }
        return NoContent();
    }
    

    [HttpPatch("{idCargoRequest:int}", Name = "UpdateCargoRequest")]
    public async Task<ActionResult> UpdateCargoRequest(int idCargoRequest, CargoRequest req) 
    {
        if (idCargoRequest != req.Id) 
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            await _cargoRepo.Update(req);
        }
        
        return NoContent();
    }

    [HttpDelete("{idCargoRequest:int}", Name = "DeleteCargoRequest")]
    public async Task<ActionResult> DeleteCargoRequest(int idCargoRequest)
    {
        await _cargoRepo.Delete(idCargoRequest);
        return NoContent();
    }
    
    [HttpGet("{searchValue}", Name = "Search")]
    public async Task<ActionResult<IEnumerable<CargoRequest>>> Search(string searchValue) 
    {
        var requests = await _cargoRepo.SearchAll(searchValue.ToLower());
        return Ok(requests);
    }
}