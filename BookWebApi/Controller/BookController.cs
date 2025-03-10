
using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Dtos.ResponseDto;
using BookWebApi.Models.Entities;
using BookWebApi.Service.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controller;

// okuma : HttpGet
// silme : HttpDelete, HttpPost
// ekleme : HttpPost
// güncelleme : HttpPatch, HttpPost, HttpPut

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{

    private readonly IBookService _service;
    public BookController(IBookService service)
    {
        _service = service;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var books = await _service.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var book = await _service.GetByIdAsync(id);
        return Ok(book);
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] BookAddRequestDto dto)
    {
        await _service.AddAsync(dto);
        return Ok("Ekleme başarılı.");
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        await _service.DeleteAsync(id);
        return Ok("Silme başarılı.");
    }

    [HttpGet("getalldetails")]
    public async Task<IActionResult> GetAllDetails()
    {
        var result = await _service.GetAllDetailsAsync();
        return Ok(result);
    }


    [HttpGet("getbycategoryid")]
    public async Task<IActionResult> GetByCategoryId([FromQuery] int categoryId)
    {
        var books = await _service.GetByCategoryIdAsync(categoryId);
        return Ok(books);
    }


}