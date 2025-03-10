using AutoMapper;
using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Dtos.ResponseDto;
using BookWebApi.Models.Entities;
using BookWebApi.Repository;
using BookWebApi.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookWebApi.Service.Concrete
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(BookAddRequestDto dto)
        {
            var book = _mapper.Map<Book>(dto);
            await _bookRepository.AddAsync(book);
        }

        public async Task UpdateAsync(BookUpdateRequestDto dto)
        {
            var existingBook = await _bookRepository.GetByIdAsync(dto.Id);
            if (existingBook == null)
                throw new Exception($"id : {dto.Id} kitap bulunamadı.");

            _mapper.Map(dto, existingBook);
            await _bookRepository.UpdateAsync(existingBook);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<List<BookResponseDto>> GetAllDetailsAsync()
        {
            var books = await _bookRepository.GetAllDetailsAsync();
            return _mapper.Map<List<BookResponseDto>>(books);
        }

        public async Task<BookResponseDto> GetDetailsByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookResponseDto>(book);
        }

        public async Task<List<BookResponseDto>> GetByCategoryIdAsync(int categoryId)
        {
            var books = await _bookRepository.GetBooksByCategoryIdAsync(categoryId);
            return _mapper.Map<List<BookResponseDto>>(books);
        }

        public async Task<List<BookResponseDto>> GetByAuthorIdAsync(int authorId)
        {
            var books = await _bookRepository.GetBooksByAuthorIdAsync(authorId);
            return _mapper.Map<List<BookResponseDto>>(books);
        }

        public async Task<List<BookResponseDto>> GetByPriceRangeDetailsAsync(double min, double max)
        {
            var books = await _bookRepository.GetAllAsync();
            var filteredBooks = books.Where(b => b.Price >= min && b.Price <= max).ToList();
            return _mapper.Map<List<BookResponseDto>>(filteredBooks);
        }

        public async Task<List<BookResponseDto>> GetByTitleContainsAsync(string title)
        {
            var books = await _bookRepository.GetAllAsync();
            var filteredBooks = books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
            return _mapper.Map<List<BookResponseDto>>(filteredBooks);
        }
    }
}