using BookWebApi.Models.Entities;

namespace BookWebApi.Repository
{
    public interface IAuthorRepository : IRepository<Author>
    {
        // Author'a özel metotlar eklenebilir
    }
}