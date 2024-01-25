using Infrastructure.Entities;

namespace Application.DTOs.SubCategoryDtos;

public class UpdateSubCategoryDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int IsFavourite { get; set; }

    public static implicit operator SubCategory(UpdateSubCategoryDto subCategoryDto)
        => new()
        {
            Id = subCategoryDto.Id,
            Name = subCategoryDto.Name,
            ImageUrl = subCategoryDto.ImageUrl,
            IsFavourite = subCategoryDto.IsFavourite,
            CategoryId = subCategoryDto.CategoryId,
        };
    public static implicit operator UpdateSubCategoryDto(SubCategory subCategoryDto)
        => new()
        {
            Id = subCategoryDto.Id,
            Name = subCategoryDto.Name,
            ImageUrl = subCategoryDto.ImageUrl,
            IsFavourite = subCategoryDto.IsFavourite,
            CategoryId = subCategoryDto.CategoryId,
        };
}
