using System.ComponentModel.DataAnnotations;

namespace VenueGuider.API.Contracts.Tag;

public record AddTagRequest(
    [Required] string Name,
    string? Description);