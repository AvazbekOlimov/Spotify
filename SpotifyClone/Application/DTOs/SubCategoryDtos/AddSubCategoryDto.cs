using Infrastructure.Entities;
namespace Application.DTOs.SubCategoryDtos;

public class AddSubCategoryDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int IsFavourite { get; set; }

    public static implicit operator SubCategory(AddSubCategoryDto subCategory)
    {
        return new SubCategory()
        {
            CategoryId = subCategory.CategoryId,
            Name = subCategory.Name,
            ImageUrl = subCategory.ImageUrl,
            IsFavourite = subCategory.IsFavourite

        };
    }
}
