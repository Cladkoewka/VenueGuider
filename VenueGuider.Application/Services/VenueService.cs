using VenueGuider.Domain.Entities;
using VenueGuider.Domain.Interfaces;

namespace VenueGuider.Application.Services;

public class VenueService
{
    private readonly IVenueRepository _venueRepository;
    private readonly ITagRepository _tagRepository;

    public VenueService(IVenueRepository venueRepository, ITagRepository tagRepository)
    {
        _venueRepository = venueRepository;
        _tagRepository = tagRepository;
    }

    public async Task<IEnumerable<Venue>> GetAllVenuesAsync()
    {
        return await _venueRepository.GetAllAsync();
    }

    public async Task<Venue?> GetVenueByIdAsync(int id)
    {
        return await _venueRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Venue>> GetVenuesByCategoryIdAsync(int categoryId)
    {
        return await _venueRepository.GetByCategoryIdAsync(categoryId);
    }

    public async Task AddVenueAsync(Venue venue)
    {
        await _venueRepository.AddAsync(venue);
    }

    public async Task UpdateVenueAsync(Venue venue)
    {
        var existingVenue = await _venueRepository.GetByIdAsync(venue.Id);
        if (existingVenue == null)
            throw new KeyNotFoundException("Venue not found");
        
        existingVenue.Name = venue.Name;
        existingVenue.CategoryId = venue.CategoryId;
        existingVenue.Address = venue.Address;
        existingVenue.Description = venue.Description;
        
        await _venueRepository.UpdateAsync(existingVenue);
    }

    public async Task DeleteVenueAsync(int id)
    {
        var venue = await _venueRepository.GetByIdAsync(id);
        if (venue == null)
            throw new KeyNotFoundException("Venue not found");

        await _venueRepository.DeleteAsync(venue);
    }
    
    public async Task AddTagToVenueAsync(int venueId, int tagId)
    {
        var venue = await _venueRepository.GetByIdAsync(venueId);
        if (venue == null) 
            throw new KeyNotFoundException("Venue not found");

        var tag = await _tagRepository.GetByIdAsync(tagId);
        if (tag == null) 
            throw new KeyNotFoundException("Tag not found");

        var venueTag = new VenueTag
        {
            VenueId = venueId,
            TagId = tagId,
            Venue = venue,
            Tag = tag
        };

        await _venueRepository.AddVenueTagAsync(venueTag);
    }

    public async Task RemoveTagFromVenueAsync(int venueId, int tagId)
    {
        await _venueRepository.DeleteVenueTagAsync(venueId, tagId);
    }

}
