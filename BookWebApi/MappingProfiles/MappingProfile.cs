using AutoMapper;
using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Dtos.ResponseDto;
using BookWebApi.Models.Entities;

namespace BookWebApi.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Book, BookResponseDto>()
            .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author != null ? src.Author.Name : ""))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : ""));
        CreateMap<BookAddRequestDto, Book>();
        CreateMap<BookUpdateRequestDto, Book>();
        CreateMap<AuthorAddRequestDto, Author>();
        CreateMap<CategoryAddRequestDto, Category>();
        CreateMap<Book, BookResponseDto>();

    }

}