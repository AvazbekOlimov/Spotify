using Application.DTOs.SubCategoryDtos;
using Application.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SubCategoryController(ISubCategoryService subCategoryService) : Controller
{
    private readonly ISubCategoryService _subcategoryServise = subCategoryService;

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var list = await _subcategoryServise.GetSubCategoriesAsync();
        return Ok(list);

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var category = await _subcategoryServise.GetSubCategoryByIdAsync(id);
            return Ok(category);
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
    public async Task<IActionResult> Post(AddSubCategoryDto subcategoryDto)
    {
        try
        {
            await _subcategoryServise.AddSubCategoryAsync(subcategoryDto);
            return Ok("Succesfully added");
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(nameof(subcategoryDto));
        }
    }
    [HttpPut("update")]
    public async Task<IActionResult> Put(UpdateSubCategoryDto updateSubCategoryDto)
    {
        try
        {
            await _subcategoryServise.UpdateSubCategoryAsync(updateSubCategoryDto);
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
            await _subcategoryServise.DeleteSubCategoryAsync(id);
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
