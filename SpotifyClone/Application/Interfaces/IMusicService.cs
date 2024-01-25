using Application.DTOs.MusicDtos;

namespace Application.Interfaces;

public interface IMusicService
{
    Task<List<MusicDto>> GetMusicsAsync();
    Task<MusicDto> GetMusicByIdAsync(int id);
    Task AddMusicAsync(AddMusicDto addmusic);
    Task UpdataMusicAsync(UpdateMusicDto updatemusic);
    Task DeleteMusicAsync(int id);
}
