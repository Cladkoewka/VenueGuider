using System.ComponentModel.DataAnnotations;

namespace VenueGuider.API.Contracts.Category;

public record UpdateCategoryRequest(
    [Required] string Name,
    string? Description);