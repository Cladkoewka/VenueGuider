using System.ComponentModel.DataAnnotations;

namespace VenueGuider.API.Contracts.Tag;

public record UpdateTagRequest(
    [Required] string Name,
    string? Description);