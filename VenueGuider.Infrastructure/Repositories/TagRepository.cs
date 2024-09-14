using Microsoft.EntityFrameworkCore;
using VenueGuider.Domain.Entities;
using VenueGuider.Domain.Interfaces;
using VenueGuider.Infrastructure.DbContext;

namespace VenueGuider.Infrastructure.Repositories;

public class TagRepository : ITagRepository
{
    private readonly ApplicationDbContext _context;

    public TagRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await _context.Tags
            .Include(t => t.VenueTags)
            .ToListAsync();
    }

    public async Task<Tag?> GetByIdAsync(int id)
    {
        return await _context.Tags
            .Include(t => t.VenueTags)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<Tag>> GetByVenueIdAsync(int venueId)
    {
        return await _context.VenueTags
            .Where(vt => vt.VenueId == venueId)
            .Select(vt => vt.Tag)
            .ToListAsync();
    }

    public async Task AddAsync(Tag tag)
    {
        await _context.Tags.AddAsync(tag);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tag tag)
    {
        _context.Tags.Update(tag);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Tag tag)
    {
        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();
    }
}