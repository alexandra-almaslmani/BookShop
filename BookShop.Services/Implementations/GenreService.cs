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
using BookShop.Persistence.DTOs.GenreDTO;

namespace BookShop.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private IRepository<Genre> _repository;
        private readonly IMapper _mapper;
        public GenreService(IRepository<Genre> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<ResultDTO> IGenreService.Add(GenreRequestDTO added)
        {
            try
            {
                var genre = _mapper.Map<Genre>(added);
                var result = await _repository.AddAsync(genre);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResultDTO> IGenreService.Delete(int id)
        {
            try
            {
                var genre = await _repository.GetByIdAsync(id);
                if (genre != null)
                {
                    var result = await _repository.DeleteAsync(id);
                    return result;
                }
                return new ResultDTO { Succeeded = false, Message = "Genre not found." };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        async Task<List<GenreResponseDTO>> IGenreService.GetAll()
        {
            try
            {
                var genres = await _repository.GetAllAsync();
                var dtogenreList = genres.Select(genre => _mapper.Map<GenreResponseDTO>(genre));
                return dtogenreList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<GenreResponseDTO> IGenreService.GetById(int id)
        {
            try
            {
                var genre = await _repository.GetByIdAsync(id);
                if (genre != null)
                {
                    var dtogenre = _mapper.Map<GenreResponseDTO>(genre);
                    return dtogenre;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResultDTO> IGenreService.Update(GenreResponseDTO updated)
        {
            try
            {
                var genre = await _repository.GetByIdAsync(updated.Id);
                if (genre == null)
                {
                    return new ResultDTO { Succeeded = false, Message = "Genres not found." };
                }
                genre.Name = updated.Name;
                genre.Description = updated.Description;
                genre.Books = updated.Books;
                var result = await _repository.UpdateAsync(genre);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
