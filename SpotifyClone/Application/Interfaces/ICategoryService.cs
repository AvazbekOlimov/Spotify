using Application.DTOs.CategoryDtos;

namespace Application.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetCategoriesAsync();
    Task<CategoryDto> GetCategoryByIdAsync(int id);
    Task AddCategoryAsync(AddCategoryDto addCategoryDto);
    Task UpdateCategoryAsync(CategoryDto CategoryDto);
    Task DeleteCategoryAsync(int id);
}
