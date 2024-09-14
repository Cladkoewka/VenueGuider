using System.ComponentModel.DataAnnotations;

namespace VenueGuider.Domain.Entities;

public class Tag
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<VenueTag> VenueTags { get; set; }
}