using BookWebApi.Models.Entities;
using BookWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookWebApi.Repository;

namespace BookWebApi.Controller;

// okuma : HttpGet
// silme : HttpDelete, HttpPost
// ekleme : HttpPost
// güncelleme : HttpPatch, HttpPost, HttpPut

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    BaseDbContext context = new BaseDbContext();
    
    
    
    [HttpPost("add")]
    public IActionResult Add([FromBody] Book book)
    {
        context.Books.Add(book);
        context.SaveChanges();

        return Ok("Ekleme başarılı");
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        List<Book> books = context.Books.ToList();
        return Ok(books);
    }
    
}