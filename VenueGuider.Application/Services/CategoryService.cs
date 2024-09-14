using VenueGuider.Domain.Entities;
using VenueGuider.Domain.Interfaces;

namespace VenueGuider.Application.Services;

public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task AddCategoryAsync(Category category)
    {
        await _categoryRepository.AddAsync(category);
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        var existingCategory = await _categoryRepository.GetByIdAsync(category.Id);
        
        if (existingCategory == null)
            throw new KeyNotFoundException("Category not found");
        
        existingCategory.Name = category.Name;
        existingCategory.Description = category.Description;
        
        await _categoryRepository.UpdateAsync(existingCategory);
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        
        if (category == null)
            throw new KeyNotFoundException("Category not found");
        
        await _categoryRepository.DeleteAsync(category);
    }
}
