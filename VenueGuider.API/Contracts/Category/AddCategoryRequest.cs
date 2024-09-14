using System.ComponentModel.DataAnnotations;

namespace VenueGuider.API.Contracts.Category;

public record AddCategoryRequest(
    [Required] string Name,
    string? Description);