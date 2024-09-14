using System.ComponentModel.DataAnnotations;

namespace VenueGuider.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Venue> Venues { get; set; }
}