using System.ComponentModel.DataAnnotations;

namespace VenueGuider.API.Contracts.Venue;

public record AddVenueRequest(
    [Required] string Name,
    [Required] int CategoryId,
    [Required] string Address,
    string? Description);