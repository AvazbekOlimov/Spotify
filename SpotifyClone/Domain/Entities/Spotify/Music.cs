namespace Infrastructure.Entities;

public class Music : BaseEntity
{
    public string Author { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Time { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public int ViewNumber { get; set; }
    public string SourceUrl { get; set; } = string.Empty;
    public string AlbumUrl { get; set; } = string.Empty;
    public string MusicText { get; set; } = string.Empty;
    public int IsFavourite { get; set; }
    public int SubCategoryId { get; set; }
    public SubCategory SubCategory { get; set; }
}
