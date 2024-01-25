using Application.DTOs.CategoryDtos;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService categoryService) : Controller
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var list = await _categoryService.GetCategoriesAsync();
        return Ok(list);

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
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
    public async Task<IActionResult> Post(AddCategoryDto categoryDto)
    {
        try
        {
            await _categoryService.AddCategoryAsync(categoryDto);
            return Ok("Succesfully added");
        }
        catch (Exception ex)
        {
            throw new ArgumentNullException(nameof(categoryDto));
        }
    }
    [HttpPut("update")]
    public async Task<IActionResult> Put(CategoryDto categoryDto)
    {
        try
        {
            await _categoryService.UpdateCategoryAsync(categoryDto);
            return Ok("MusicCategory Updated");
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
            await _categoryService.DeleteCategoryAsync(id);
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
