using Infrastructure.Entities;

namespace Application.DTOs.CategoryDtos;

public class AddCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int IsFavourite { get; set; }

    public static implicit operator Category(AddCategoryDto category)
    {
        return new Category()
        {
            Name = category.Name,
            ImageUrl = category.ImageUrl,
            IsFavourite = category.IsFavourite,
        };
    }
}
