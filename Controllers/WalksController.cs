namespace WebApplication1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApplication1.Models.Domain;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Repositories;
using WebApplication1.CustomActionFilter;

[Route("/api/[controller]")]
[ApiController]

public class WalksController: ControllerBase{
    private readonly IWalksRepository _walksRepository;
    public WalksController(IWalksRepository WalksRepository)//injecting the db context that we have registered in program.cs
    {
        _walksRepository = WalksRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? filteron, [FromQuery] string? filterquery)
    {
        var walks=await _walksRepository.GetAllAsync(filteron,filterquery);
        if(walks.Count==0){
            return NotFound("No walks found");
        }
        return Ok(walks);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id){
        var walks=await _walksRepository.GetByIdAsync(id);
        if(walks==null){
            return NotFound($"Walks with ID {id} not found.");
        }
        return Ok(walks);
    }

    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> Create([FromBody] Walks walks){
        
            if(walks==null){
            return BadRequest("Invalid walks data.");
            }
            await _walksRepository.CreateAsync(walks);
            return CreatedAtAction(nameof(GetAll), new { id = walks.Id }, walks);
        
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id){
        var walks = await _walksRepository.GetByIdAsync(id);
        if(walks==null){
            return NotFound($"Walks with ID {id} not found.");
        }
        await _walksRepository.DeleteAsync(id);
        return Ok($"Walks with ID {id} deleted successfully.");
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody] Walks updatedwalks){
        if(updatedwalks==null){
            return BadRequest("Invalid walks data.");
        }
        var walks=await _walksRepository.UpdateAsync(id,updatedwalks);
        if(walks==null){
            return NotFound($"Walks with ID {id} not found.");
        }
        return Ok(walks);   
    }   
}
