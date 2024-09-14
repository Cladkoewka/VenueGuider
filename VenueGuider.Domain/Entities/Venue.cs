using System.ComponentModel.DataAnnotations;

namespace VenueGuider.Domain.Entities;

public class Venue
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    [Required]
    public string Address { get; set; }
    public string? Description { get; set; }
    public ICollection<VenueTag> VenueTags { get; set; }
}