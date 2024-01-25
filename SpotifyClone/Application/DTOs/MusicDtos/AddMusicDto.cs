using Infrastructure.Entities;

namespace Application.DTOs.MusicDtos;

public class AddMusicDto
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

    public static implicit operator Music(AddMusicDto music)
    {
        return new Music()
        {
            Author = music.Author,
            Title = music.Title,
            Time = music.Time,
            CreatedDate = music.CreatedDate,
            ViewNumber = music.ViewNumber,
            SourceUrl = music.SourceUrl,
            AlbumUrl = music.AlbumUrl,
            MusicText = music.MusicText,
            IsFavourite = music.IsFavourite,
            SubCategoryId = music.SubCategoryId
        };
    }
}
