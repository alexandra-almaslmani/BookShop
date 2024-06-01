using AutoMapper;
using BookShop.Persistence.DTOs.AuthorDTO;
using BookShop.Persistence.DTOs.BookDTO;
using BookShop.Persistence.DTOs.CustomerDTO;
using BookShop.Persistence.DTOs.GenreDTO;
using BookShop.Persistence.DTOs.OrderDTO;
using BookShop.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Persistence.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BookRequestDTO, Book>();
            CreateMap<Book, BookResponseDTO>();

            CreateMap<CustomerRequestDTO, Customer>();
            CreateMap<Customer, CustomerResponseDTO>();

            CreateMap<AuthorRequestDTO, Author>();
            CreateMap<Author, AuthorResponseDTO>();

            CreateMap<GenreRequestDTO, Genre>();
            CreateMap<Genre, GenreResponseDTO>();

            CreateMap<OrderRequestDTO, Order>();
            CreateMap<Order, OrderResponseDTO>();
        }
    }
}
