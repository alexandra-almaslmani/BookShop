using AutoMapper;
using BookShop.Persistence.DTOs.BookDTO;
using BookShop.Persistence.DTOs;
using BookShop.Persistence.Entities;
using BookShop.Persistence.IRepositories;
using BookShop.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Persistence.DTOs.AuthorDTO;

namespace BookShop.Services.Implementations
{
    public class AuthorService :IAuthorService
    {
        private IRepository<Author> _repository;
        private readonly IMapper _mapper;
        public AuthorService(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<ResultDTO> IAuthorService.Add(AuthorRequestDTO added)
        {
            try
            {
                var author = _mapper.Map<Author>(added);
                var result = await _repository.AddAsync(author);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResultDTO> IAuthorService.Delete(int id)
        {
            try
            {
                var author = await _repository.GetByIdAsync(id);
                if (author != null)
                {
                    var result = await _repository.DeleteAsync(id);
                    return result;
                }
                return new ResultDTO { Succeeded = false, Message = "Author not found." };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        async Task<List<AuthorResponseDTO>> IAuthorService.GetAll()
        {
            try
            {
                var authors = await _repository.GetAllAsync();
                var dtoAuhtorList = authors.Select(author => _mapper.Map<AuthorResponseDTO>(author));
                return dtoAuhtorList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<AuthorResponseDTO> IAuthorService.GetById(int id)
        {
            try
            {
                var auhtor = await _repository.GetByIdAsync(id);
                if (auhtor != null)
                {
                    var dtoAuthor = _mapper.Map<AuthorResponseDTO>(auhtor);
                    return dtoAuthor;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResultDTO> IAuthorService.Update(AuthorResponseDTO updated)
        {
            try
            {
                var author = await _repository.GetByIdAsync(updated.Id);
                if (author == null)
                {
                    return new ResultDTO { Succeeded = false, Message = "Author not found." };
                }
                author.Name = updated.Name;
                author.Bio = updated.Bio;
                author.BirthDate = updated.BirthDate;
                var result = await _repository.UpdateAsync(author);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
