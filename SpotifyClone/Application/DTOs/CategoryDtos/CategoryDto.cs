using Infrastructure.Entities;

namespace Application.DTOs.CategoryDtos;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int IsFavourite { get; set; }

    public static implicit operator CategoryDto(Category category)
    {
        return new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name,
            ImageUrl = category.ImageUrl,
            IsFavourite = category.IsFavourite,
        };
    }
    public static implicit operator Category(CategoryDto category)
    {
        return new Category()
        {
            Id = category.Id,
            Name = category.Name,
            ImageUrl = category.ImageUrl,
            IsFavourite = category.IsFavourite,
        };
    }
}
