using BookWebApi.Models.Entities;

namespace BookWebApi.Repository
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> GetBooksByCategoryIdAsync(int categoryId);
        Task<List<Book>> GetBooksByAuthorIdAsync(int authorId);
        Task<List<Book>> GetAllDetailsAsync();
    }
}