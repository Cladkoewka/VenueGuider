using Microsoft.AspNetCore.Mvc;
using VenueGuider.API.Contracts.Venue;
using VenueGuider.Application.Services;
using VenueGuider.Domain.Entities;

namespace VenueGuider.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VenueController : ControllerBase
{
    private readonly VenueService _venueService;

    public VenueController(VenueService venueService)
    {
        _venueService = venueService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVenues()
    {
        var venues = await _venueService.GetAllVenuesAsync();
        return Ok(venues);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVenueById(int id)
    {
        var venue = await _venueService.GetVenueByIdAsync(id);
        
        if (venue == null)
            return NotFound();
        
        return Ok(venue);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetVenuesByCategoryId(int categoryId)
    {
        var venues = await _venueService.GetVenuesByCategoryIdAsync(categoryId);
        return Ok(venues);
    }

    [HttpPost]
    public async Task<IActionResult> AddVenue([FromBody] AddVenueRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var venue = new Venue
        {
            Name = request.Name,
            CategoryId = request.CategoryId,
            Address = request.Address,
            Description = request.Description
        };
        
        await _venueService.AddVenueAsync(venue);
        return CreatedAtAction(nameof(GetVenueById), new { id = venue.Id }, venue);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVenue(int id, [FromBody] UpdateVenueRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var venue = new Venue
        {
            Id = id,
            Name = request.Name,
            CategoryId = request.CategoryId,
            Address = request.Address,
            Description = request.Description
        };
        
        await _venueService.UpdateVenueAsync(venue);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVenue(int id)
    {
        await _venueService.DeleteVenueAsync(id);
        return NoContent();
    }
}
