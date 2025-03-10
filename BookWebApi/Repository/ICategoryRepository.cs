using BookWebApi.Models.Entities;

namespace BookWebApi.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        // Kategoriye özel metotlar eklenebilir
    }
}