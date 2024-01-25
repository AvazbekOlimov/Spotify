using Application.DTOs.SubCategoryDtos;

namespace Application.Interfaces;

public interface ISubCategoryService
{
    Task<List<SubCategoryDto>> GetSubCategoriesAsync();
    Task<SubCategoryDto> GetSubCategoryByIdAsync(int id);
    Task AddSubCategoryAsync(AddSubCategoryDto addSubCategoryDto);
    Task UpdateSubCategoryAsync(UpdateSubCategoryDto updateSubCategoryDto);
    Task DeleteSubCategoryAsync(int id);
}
