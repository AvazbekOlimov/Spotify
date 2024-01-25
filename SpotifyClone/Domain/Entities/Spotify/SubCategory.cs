namespace Infrastructure.Entities;

public class SubCategory : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Musics { get; set; }
    public int IsFavourite { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } 
    public ICollection<Music> Music { get; set; } = new List<Music>();
}
