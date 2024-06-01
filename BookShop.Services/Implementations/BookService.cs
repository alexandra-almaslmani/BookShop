using AutoMapper;
using BookShop.Persistence.DTOs;
using BookShop.Persistence.DTOs.BookDTO;
using BookShop.Persistence.Entities;
using BookShop.Persistence.IRepositories;
using BookShop.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Services.Implementations
{
    public class BookService : IBookService
    {
        private IRepository<Book> _repository;
        private readonly IMapper _mapper;
        public BookService(IRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<ResultDTO> IBookService.Add(BookRequestDTO added)
        {
            try
            {
                var book = _mapper.Map<Book>(added);
                var result = await _repository.AddAsync(book);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResultDTO> IBookService.Delete(int id)
        {
            try
            {
                var book = await _repository.GetByIdAsync(id);
                if(book != null)
                {
                    var result = await _repository.DeleteAsync(id);
                    return result;
                }
                return new ResultDTO { Succeeded = false, Message = "Book not found." };
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        async Task<List<BookResponseDTO>> IBookService.GetAll()
        {
            try
            {
                var books = await _repository.GetAllAsync();
                var dtoBookList = books.Select(book => _mapper.Map<BookResponseDTO>(book));
                return dtoBookList.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        async Task<BookResponseDTO> IBookService.GetById(int id)
        {
            try
            {
                //var books = await _repository.GetByConditionAsync(i => i.Id == id);
                var book = await _repository.GetByIdAsync(id);
                if (book != null)
                {
                    var dtoBook = _mapper.Map<BookResponseDTO>(book);
                    return dtoBook;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResultDTO> IBookService.Update(BookResponseDTO updated)
        {
            try
            {
                var book = await _repository.GetByIdAsync(updated.Id);
                if(book == null)
                {
                    return new ResultDTO { Succeeded = false, Message = "Book not found." };
                }
                book.Title = updated.Title;
                book.AuthorId = updated.AuthorId;
                book.Price = updated.Price;
                book.GenreId = book.GenreId;
                var result = await _repository.UpdateAsync(book);
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
