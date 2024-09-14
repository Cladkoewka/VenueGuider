using VenueGuider.Domain.Entities;
using VenueGuider.Domain.Interfaces;

namespace VenueGuider.Application.Services;

public class TagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<IEnumerable<Tag>> GetAllTagsAsync()
    {
        return await _tagRepository.GetAllAsync();
    }

    public async Task<Tag?> GetTagByIdAsync(int id)
    {
        return await _tagRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Tag>> GetTagsByVenueIdAsync(int venueId)
    {
        return await _tagRepository.GetByVenueIdAsync(venueId);
    }

    public async Task AddTagAsync(Tag tag)
    {
        await _tagRepository.AddAsync(tag);
    }

    public async Task UpdateTagAsync(Tag tag)
    {
        var existingTag = await _tagRepository.GetByIdAsync(tag.Id);
        if (existingTag == null)
            throw new KeyNotFoundException("Tag not found");
        
        existingTag.Name = tag.Name;
        existingTag.Description = tag.Description;
        
        await _tagRepository.UpdateAsync(existingTag);
    }

    public async Task DeleteTagAsync(int id)
    {
        var tag = await _tagRepository.GetByIdAsync(id);
        if (tag == null)
            throw new KeyNotFoundException("Tag not found");

        await _tagRepository.DeleteAsync(tag);
    }
}
