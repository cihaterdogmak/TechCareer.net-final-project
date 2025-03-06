using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Entities;

namespace BookWebApi.Service.Interfaces;

public interface IAuthorService
{
    void Add(AuthorAddRequestDto dto);
    void AddMultiple(List<AuthorAddRequestDto> dtos);
    
    List<Author> GetAll();
    
    Author GetById(int id);
}