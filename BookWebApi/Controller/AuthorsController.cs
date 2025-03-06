using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Entities;
using BookWebApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controller;

[Route("api/[controller]")]
[ApiController]

public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _service;
    
    public AuthorsController(IAuthorService service)
    {
        _service = service;
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] AuthorAddRequestDto dto)
    {
        _service.Add(dto);
        return Ok(dto);
    }
    
    [HttpPost("addmultiple")]
    public IActionResult AddMultiple([FromBody] List<AuthorAddRequestDto> dtos)
    {
        if (dtos == null || dtos.Count == 0)
            return BadRequest("Boş yazar listesi gönderilemez.");

        _service.AddMultiple(dtos);
        return Ok($"{dtos.Count} yazar başarıyla eklendi.");
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        List<Author> authors = _service.GetAll();
        return Ok(authors);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] int id)
    {
        Author author = _service.GetById(id);
        return Ok(author);
    }

}