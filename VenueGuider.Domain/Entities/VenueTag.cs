namespace VenueGuider.Domain.Entities;

public class VenueTag
{
    public int VenueId { get; set; }
    public Venue Venue { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
}