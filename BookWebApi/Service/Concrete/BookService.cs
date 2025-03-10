using AutoMapper;
using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Dtos.ResponseDto;
using BookWebApi.Models.Entities;
using BookWebApi.Repository;
using BookWebApi.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Service.Concrete;

//Repository Pattern yöntemi kullanıldı IBookService interface ini kullanarak gerekli satırları iplemente edilmiştir.
public class BookService : IBookService
{


    private readonly BaseDbContext _context;
    private readonly IMapper _mapper;

    public BookService(BaseDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }



    public List<Book> GetAll()
    {
        List<Book> books = _context.Books.ToList();
        return books;
    }

    public Book GetById(int id)
    {
        Book? book = _context.Books.Find(id);
        if (book == null)
        {
            throw new Exception($"id : {id} kitap bulunamadı.");
        }
        return book;
    }

    public void Update(BookUpdateRequestDto dto)
    {
        Book? book = _context.Books.Find(dto.Id);
        if (book == null)
        {
            throw new Exception($"id : {dto.Id} kitap bulunamadı.");
        }

        Book updatedBook = _mapper.Map<Book>(dto);
        _context.Books.Update(updatedBook);
        _context.SaveChanges();


    }

    public void Add(BookAddRequestDto dto)
    {
        Book book = _mapper.Map<Book>(dto);
        _context.Books.Add(book);
        _context.SaveChanges();

    }

    public void AddMultiple(List<BookAddRequestDto> dtos)
    {
        List<Book> newBook = _mapper.Map<List<Book>>(dtos);
        _context.Books.AddRange(newBook);
        _context.SaveChanges();

    }

    public void Delete(int id)
    {
        Book? book = _context.Books.Find(id);
        if (book == null)
        {
            throw new Exception($"id : {id} kitap bulunamadı");
        }
        _context.Books.Remove(book);
        _context.SaveChanges();
    }

    public List<BookResponseDto> GetAllDetails()
    {
        List<Book> books = _context.Books
            .Include(x => x.Author)
            .Include(x => x.Category)
            .ToList();
        List<BookResponseDto> responses = _mapper
            .Map<List<BookResponseDto>>(books);

        return responses;
    }

    public BookResponseDto GetDetailsById(int id)
    {
        Book? book = _context.Books
            .Include(x => x.Author)
            .Include(x => x.Category)
            .SingleOrDefault(x => x.Id == id);

        if (book == null)
        {
            throw new Exception($"id {id} kitap bulunamadı.");
        }

        BookResponseDto response = _mapper.Map<BookResponseDto>(book);
        return response;
    }

    public List<BookResponseDto> GetByCategoryId(int categoryId)
    {
        List<Book> books = _context.Books
            .Include(x => x.Author)
            .Include(x => x.Category)
            .Where(x => x.CategoryId == categoryId)
            .ToList();

        List<BookResponseDto> responses = _mapper
            .Map<List<BookResponseDto>>(books);

        return responses;
    }

    public List<BookResponseDto> GetByAuthorId(int authorId)
    {
        List<Book> books = _context.Books
            .Include(x => x.Author)
            .Include(x => x.Category)
            .Where(x => x.AuthorId == authorId)
            .ToList();

        List<BookResponseDto> responses = _mapper
            .Map<List<BookResponseDto>>(books);

        return responses;
    }

    public List<BookResponseDto> GetByPriceRangeDetails(double min, double max)
    {
        List<Book> books = _context.Books
            .Include(x => x.Author)
            .Include(x => x.Category)
            .Where(x => x.Price <= max && x.Price > min)
            .ToList();

        List<BookResponseDto> responses = _mapper
            .Map<List<BookResponseDto>>(books);

        return responses;
    }

    public List<BookResponseDto> GetByTitleContains(string title)
    {
        List<Book> books = _context.Books
            .Include(x => x.Author)
            .Include(x => x.Category)
            .Where(x => x.Title == title)
            .ToList();

        List<BookResponseDto> responses = _mapper
            .Map<List<BookResponseDto>>(books);

        return responses;
    }
}