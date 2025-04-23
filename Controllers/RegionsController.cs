using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplication1.Models.Domain;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositories;
namespace WebApplication1.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class RegionsController : ControllerBase
{

    private readonly ProjDBcontext _dbContext;
    private readonly IRegionRepository _regionRepository;
    public RegionsController(ProjDBcontext dbContext,IRegionRepository RegionRepository)//injecting the db context that we have registered in program.cs
    {
        _dbContext = dbContext;
        _regionRepository = RegionRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var regions=await _regionRepository.GetAllAsync();
        if(regions.Count==0){
            return NotFound("No regions found");
        }
        return Ok(regions);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var region =await  _regionRepository.GetByIdAsync(id);
        if (region == null)
        {
            return NotFound($"Region with ID {id} not found.");
        }
        return Ok(region);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Regions regions)
    {
        if (regions == null)
        {
            return BadRequest("Invalid region data.");
        }

        await _regionRepository.CreateAsync(regions);

        return CreatedAtAction(nameof(GetAll), new { id = regions.Id }, regions);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var region = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        if (region == null)
        {
            return NotFound($"Region with ID {id} not found.");
        }


        await _regionRepository.DeleteAsync(id);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] Regions updatedRegion)
    {
        if (updatedRegion == null)
        {
            return BadRequest("Invalid region data.");
        }

        var region=await _regionRepository.UpdateAsync(id, updatedRegion);
        Console.WriteLine(region);

        return NoContent();
    }
}