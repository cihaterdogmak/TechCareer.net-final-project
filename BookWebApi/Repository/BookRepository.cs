using BookWebApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly BaseDbContext _context;

        public BookRepository(BaseDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<List<Book>> GetBooksByAuthorIdAsync(int authorId)
        {
            return await _context.Books.Where(b => b.AuthorId == authorId).ToListAsync();
        }

        // public async Task<List<Book>> GetBooksByCategoryIdAsync(int categoryId)
        // {
        //     return await _context.Books.Where(b => b.CategoryId == categoryId).ToListAsync();
        // }
        public async Task<List<Book>> GetBooksByCategoryIdAsync(int categoryId)
        {
            return await _context.Books
            .Where(b => b.CategoryId == categoryId) // SQL seviyesinde filtreleme yapılıyor!
            .Include(b => b.Author)   // Yazar bilgisi de çekiliyor
            .Include(b => b.Category) // Kategori bilgisi de çekiliyor
            .ToListAsync();
        }


        public async Task<List<Book>> GetAllDetailsAsync()
        {
            return await _context.Books
                .Include(b => b.Author)   // Yazar bilgilerini dahil et
                .Include(b => b.Category) // Kategori bilgilerini dahil et
                .ToListAsync();
        }
    }
}