using Microsoft.EntityFrameworkCore;
using VenueGuider.Domain.Entities;
using VenueGuider.Domain.Interfaces;
using VenueGuider.Infrastructure.DbContext;

namespace VenueGuider.Infrastructure.Repositories;

public class VenueRepository : IVenueRepository
{
    private readonly ApplicationDbContext _context;

    public VenueRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Venue>> GetAllAsync()
    {
        return await _context.Venues
            .Include(v => v.Category)
            .Include(v => v.VenueTags) 
                .ThenInclude(vt => vt.Tag)
            .ToListAsync();
    }

    public async Task<Venue?> GetByIdAsync(int id)
    {
        return await _context.Venues
            .Include(v => v.Category)
            .Include(v => v.VenueTags)
                .ThenInclude(vt => vt.Tag) 
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<IEnumerable<Venue>> GetByCategoryIdAsync(int categoryId)
    {
        return await _context.Venues
            .Where(v => v.CategoryId == categoryId)
            .Include(v => v.Category)
            .Include(v => v.VenueTags)
                .ThenInclude(vt => vt.Tag) 
            .ToListAsync();
    }

    public async Task AddAsync(Venue venue)
    {
        await _context.Venues.AddAsync(venue);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Venue venue)
    {
        _context.Venues.Update(venue);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Venue venue)
    {
        _context.Venues.Remove(venue);
        await _context.SaveChangesAsync();
    }
    
    public async Task AddVenueTagAsync(VenueTag venueTag)
    {
        var existingVenueTag = await _context.VenueTags
            .FirstOrDefaultAsync(vt => vt.VenueId == venueTag.VenueId && vt.TagId == venueTag.TagId);
    
        if (existingVenueTag == null)
        {
            await _context.VenueTags.AddAsync(venueTag);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteVenueTagAsync(int venueId, int tagId)
    {
        var venueTag = await _context.VenueTags
            .FirstOrDefaultAsync(vt => vt.VenueId == venueId && vt.TagId == tagId);
    
        if (venueTag != null)
        {
            _context.VenueTags.Remove(venueTag);
            await _context.SaveChangesAsync();
        }
    }
}
