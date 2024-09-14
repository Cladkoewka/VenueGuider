using VenueGuider.Domain.Entities;

namespace VenueGuider.Domain.Interfaces;

public interface ITagRepository
{
    Task<IEnumerable<Tag>> GetAllAsync();
    Task<Tag?> GetByIdAsync(int id);
    Task<IEnumerable<Tag>> GetByVenueIdAsync(int venueId);
    Task AddAsync(Tag tag);
    Task UpdateAsync(Tag tag);
    Task DeleteAsync(Tag tag);
}