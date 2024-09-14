using Microsoft.AspNetCore.Mvc;
using VenueGuider.API.Contracts.Category;
using VenueGuider.Application.Services;
using VenueGuider.Domain.Entities;

namespace VenueGuider.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoryController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        
        if (category == null) 
            return NotFound();
        
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var category = new Category
        {
            Name = request.Name,
            Description = request.Description
        };
        
        await _categoryService.AddCategoryAsync(category);
        
        return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var category = new Category
        {
            Id = id,
            Name = request.Name,
            Description = request.Description
        };
        
        await _categoryService.UpdateCategoryAsync(category);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return NoContent();
    }
}