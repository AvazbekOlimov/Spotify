namespace Infrastructure.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int IsFavourite { get; set; }
    public ICollection<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
}
