using System.ComponentModel.DataAnnotations;

namespace VenueGuider.API.Contracts.Venue;

public record UpdateVenueRequest(
    [Required] string Name,
    [Required] int CategoryId,
    [Required] string Address,
    string? Description);