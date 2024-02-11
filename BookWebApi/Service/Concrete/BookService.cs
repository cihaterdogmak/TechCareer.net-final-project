using AutoMapper;
using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Entities;
using BookWebApi.Repository;
using BookWebApi.Service.Interfaces;

namespace BookWebApi.Service.Concrete;

//Repository Pattern yöntemi kullanıldı IBookService interface ini kullanarak gerekli satırları iplemente edilmiştir.
public class BookService: IBookService
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
}