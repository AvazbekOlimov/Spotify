using Application.DTOs.MusicDtos;
using Application.Interfaces;
using Application.Services;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MusicController(IMusicService musicService) : Controller
{

    string accountName = "spotifyblobstorage";
    string accountKey = "KV17Z9BfnEyvXirbw2VDhP6dO3buQ74+6LRJdxUMgXmH+sHrSDkKFcMORrKRlWpAAxtx62uDktkn+AStXqsbsg==";

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
    [HttpGet("Musics")]
    public async Task<ActionResult<List<string>>> GetMusicsMusic()
    {
        
        string containerName = "musics";

        var blobServiceClient = new BlobServiceClient($"DefaultEndpointsProtocol=https;AccountName={accountName};AccountKey={accountKey};EndpointSuffix=core.windows.net");

        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        List<string> blobUrls = new List<string>();

        // List blobs in the container
        await foreach (var blobItem in containerClient.GetBlobsAsync())
        {
            var blobClient = containerClient.GetBlobClient(blobItem.Name);
            var blobUrl = blobClient.Uri.ToString();
            blobUrls.Add(blobUrl);
        }

        return Ok(blobUrls);
    }
    [HttpGet("Albums")]
    public async Task<ActionResult<List<string>>> GetMusicsAlbum()
    {

        string containerName = "album";

        var blobServiceClient = new BlobServiceClient($"DefaultEndpointsProtocol=https;AccountName={accountName};AccountKey={accountKey};EndpointSuffix=core.windows.net");

        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        List<string> blobUrls = new List<string>();

        // List blobs in the container
        await foreach (var blobItem in containerClient.GetBlobsAsync())
        {
            var blobClient = containerClient.GetBlobClient(blobItem.Name);
            var blobUrl = blobClient.Uri.ToString();
            blobUrls.Add(blobUrl);
        }

        return Ok(blobUrls);
    }
    [HttpGet("Text")]
    public async Task<ActionResult<List<string>>> GetMusicsText()
    {

        string containerName = "text";

        var blobServiceClient = new BlobServiceClient($"DefaultEndpointsProtocol=https;AccountName={accountName};AccountKey={accountKey};EndpointSuffix=core.windows.net");

        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);

        List<string> blobUrls = new List<string>();

        // List blobs in the container
        await foreach (var blobItem in containerClient.GetBlobsAsync())
        {
            var blobClient = containerClient.GetBlobClient(blobItem.Name);
            var blobUrl = blobClient.Uri.ToString();
            blobUrls.Add(blobUrl);
        }

        return Ok(blobUrls);
    }
}
