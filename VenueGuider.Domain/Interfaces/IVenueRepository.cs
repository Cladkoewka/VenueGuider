using VenueGuider.Domain.Entities;

namespace VenueGuider.Domain.Interfaces;

public interface IVenueRepository
{
    Task<IEnumerable<Venue>> GetAllAsync();
    Task<Venue?> GetByIdAsync(int id);
    Task<IEnumerable<Venue>> GetByCategoryIdAsync(int categoryId);
    Task AddAsync(Venue venue);
    Task UpdateAsync(Venue venue);
    Task DeleteAsync(Venue venue);
}