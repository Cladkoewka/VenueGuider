using Microsoft.AspNetCore.Mvc;
using VenueGuider.API.Contracts.Tag;
using VenueGuider.Application.Services;
using VenueGuider.Domain.Entities;

namespace VenueGuider.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController : ControllerBase
{
    private readonly TagService _tagService;

    public TagController(TagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTags()
    {
        var tags = await _tagService.GetAllTagsAsync();
        
        return Ok(tags);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagById(int id)
    {
        var tag = await _tagService.GetTagByIdAsync(id);
        
        if (tag == null) 
            return NotFound();
        
        return Ok(tag);
    }

    [HttpPost]
    public async Task<IActionResult> AddTag([FromBody] AddTagRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var tag = new Tag
        {
            Name = request.Name,
            Description = request.Description
        };
        
        await _tagService.AddTagAsync(tag);
        return CreatedAtAction(nameof(GetTagById), new { id = tag.Id }, tag);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTag(int id, [FromBody] UpdateTagRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var tag = new Tag
        {
            Id = id,
            Name = request.Name,
            Description = request.Description
        };
        
        await _tagService.UpdateTagAsync(tag);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
        await _tagService.DeleteTagAsync(id);
        return NoContent();
    }
}
