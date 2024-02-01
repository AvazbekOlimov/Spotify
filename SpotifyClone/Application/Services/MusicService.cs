using Application.Common.Exceptions;
using Application.DTOs.MusicDtos;
using Application.Interfaces;
using Azure.Storage.Blobs;
using Infrastructure.Entities;
using Infrastructure.Interfaces;

namespace Application.Services;

public class MusicService(IUnitOfWork unitOfWork) : IMusicService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
   

    public async Task AddMusicAsync(AddMusicDto addmusic)
    {
        if (addmusic == null)
        {
            throw new CustomException("Category is null !");
        }

        var model = (Music)addmusic;

        await _unitOfWork.Music.AddAsync(model);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteMusicAsync(int id)
    {
        var category = await _unitOfWork.Music.GetByIdAsync(id);
        await _unitOfWork.Music.DeleteAsync(category);
        await _unitOfWork.SaveAsync();
    }

    public async Task<MusicDto> GetMusicByIdAsync(int id)
    {
        var music = await _unitOfWork.Music.GetByIdAsync(id);

        return (MusicDto)music;
    }

    public async Task<List<MusicDto>> GetMusicsAsync()
    {
        var musics = await _unitOfWork.Music.GetAllAsync();
        return musics.Select(c => (MusicDto)c).ToList();
    }

    public async Task UpdataMusicAsync(UpdateMusicDto updatemusic)
    {
        var model = (Music)updatemusic;
        await _unitOfWork.Music.UpdateAsync(model);
    }

   
}
