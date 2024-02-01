using Application.DTOs.MusicDtos;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MusicController(IMusicService musicService) : Controller
{
    

    private readonly IMusicService _musicService = musicService;
    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var list = await _musicService.GetMusicsAsync();
        return Ok(list);

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var music = await _musicService.GetMusicByIdAsync(id);
            return Ok(music);
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post(AddMusicDto addmusic)
    {
        try
        {
            await _musicService.AddMusicAsync(addmusic);
            return Ok("Succesfully added");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message); 
        }
    }
    [HttpPut("update")]
    public async Task<IActionResult> Put(UpdateMusicDto updateMusicDto)
    {
        try
        {
            await _musicService.UpdataMusicAsync(updateMusicDto);
            return Ok("GameCategory Updated");
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _musicService.DeleteMusicAsync(id);
            return Ok();
        }
        catch (ArgumentNullException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
