using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Dtos.ResponseDto;
using BookWebApi.Models.Entities;

namespace BookWebApi.Service.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task AddAsync(BookAddRequestDto dto);
        Task UpdateAsync(BookUpdateRequestDto dto);
        Task DeleteAsync(int id);
        Task<List<BookResponseDto>> GetAllDetailsAsync();
        Task<BookResponseDto> GetDetailsByIdAsync(int id);
        Task<List<BookResponseDto>> GetByCategoryIdAsync(int categoryId);
        Task<List<BookResponseDto>> GetByAuthorIdAsync(int authorId);
        Task<List<BookResponseDto>> GetByPriceRangeDetailsAsync(double min, double max);
        Task<List<BookResponseDto>> GetByTitleContainsAsync(string title);
    }
}