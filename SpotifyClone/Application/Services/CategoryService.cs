using Application.Common.Exceptions;
using Application.DTOs.CategoryDtos;
using Application.Interfaces;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Application.Services;

public class CategoryService(IUnitOfWork unitOfWork) : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task AddCategoryAsync(AddCategoryDto addCategoryDto)
    {
        if (addCategoryDto == null)
        {
            throw new CustomException("Category is null !");
        }

        var model = (AddCategoryDto)addCategoryDto;

        await _unitOfWork.Category.AddAsync((Category)model);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(id);
        await _unitOfWork.Category.DeleteAsync(category);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<CategoryDto>> GetCategoriesAsync()
    {
        var categories = await _unitOfWork.Category.GetAllAsync();
        return categories.Select(c => (CategoryDto)c).ToList();
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _unitOfWork.Category.GetByIdAsync(id);

        return (CategoryDto)category;
    }

    public async Task UpdateCategoryAsync(CategoryDto categoryDto)
    {
        var model = (Category)categoryDto;
        await _unitOfWork.Category.UpdateAsync(model);
    }
}
