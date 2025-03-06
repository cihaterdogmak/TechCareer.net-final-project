using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Entities;
using BookWebApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controller;

[Route("api/[controller]")]
[ApiController]

public class CategoryController : ControllerBase
{
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    private readonly ICategoryService _categoryService;

    
    
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        List<Category> categories = _categoryService.GetAll();
        return Ok(categories);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] int id)
    {
        Category category = _categoryService.GetById(id);
        return Ok(category);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CategoryAddRequestDto dto)
    {
        _categoryService.Add(dto);
        return Ok();
    }
    
    [HttpPost("addmultiple")]
    public IActionResult AddMultiple([FromBody] List<CategoryAddRequestDto> dtos)
    {
        _categoryService.AddMultiple(dtos);
        return Ok($"{dtos.Count} kategori başarıyla eklendi.");
    }

}