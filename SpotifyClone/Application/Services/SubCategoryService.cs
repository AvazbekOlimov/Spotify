
using Application.Common.Exceptions;
using Application.DTOs.SubCategoryDtos;
using Application.Interfaces;
using Infrastructure.Interfaces;

namespace Application.Services;

public class SubCategoryService(IUnitOfWork unitOfWork) : ISubCategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task AddSubCategoryAsync(AddSubCategoryDto addSubCategoryDto)
    {
        if (addSubCategoryDto == null)
        {
            throw new CustomException("SubCategory is null");
        }
        var model = (AddSubCategoryDto)addSubCategoryDto;
        await _unitOfWork.SubCategory.AddAsync(model);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteSubCategoryAsync(int id)
    {
        var subcategory = await _unitOfWork.SubCategory.GetByIdAsync(id);
        await _unitOfWork.SubCategory.DeleteAsync(subcategory);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<SubCategoryDto>> GetSubCategoriesAsync()
    {

        var subcategories = await _unitOfWork.SubCategory.GetAllAsync();
        return subcategories.Select(subcategory => (SubCategoryDto)subcategory).ToList();
    }

    public async Task<SubCategoryDto> GetSubCategoryByIdAsync(int id)
    {
        var subcategory = await _unitOfWork.SubCategory.GetByIdAsync(id);
        return (SubCategoryDto)subcategory;
    }

    public async Task UpdateSubCategoryAsync(UpdateSubCategoryDto updateSubCategoryDto)
    {
        var model = (UpdateSubCategoryDto)updateSubCategoryDto;
        await _unitOfWork.SubCategory.UpdateAsync(model);
    }
}
