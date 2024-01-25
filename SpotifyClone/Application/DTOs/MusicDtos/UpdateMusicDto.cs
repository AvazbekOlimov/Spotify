using Infrastructure.Entities;

namespace Application.DTOs.MusicDtos;

public class UpdateMusicDto
{
    public int Id { get; set; }
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
    public static implicit operator Music(UpdateMusicDto updatemusic)
    {
        return new()
        {
            Id = updatemusic.Id,
            Author = updatemusic.Author,
            Title = updatemusic.Title,
            Time = updatemusic.Time,
            CreatedDate = updatemusic.CreatedDate,
            ViewNumber = updatemusic.ViewNumber,
            SourceUrl = updatemusic.SourceUrl,
            AlbumUrl = updatemusic.AlbumUrl,
            MusicText = updatemusic.MusicText,
            IsFavourite = updatemusic.IsFavourite
        };
    }
    public static implicit operator UpdateMusicDto(Music music)
    {
        return new()
        {
            Id = music.Id,
            Author = music.Author,
            Title = music.Title,
            Time = music.Time,
            CreatedDate = music.CreatedDate,
            ViewNumber = music.ViewNumber,
            AlbumUrl = music.AlbumUrl,
            MusicText = music.MusicText,
            IsFavourite = music.IsFavourite
        };
    }
}
