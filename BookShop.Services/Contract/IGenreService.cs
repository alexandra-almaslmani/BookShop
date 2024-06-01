using BookShop.Persistence.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Persistence.DTOs.GenreDTO;

namespace BookShop.Services.Contract
{
    public interface IGenreService
    {
        public Task<ResultDTO> Add(GenreRequestDTO added);
        public Task<ResultDTO> Update(GenreResponseDTO updated);
        public Task<ResultDTO> Delete(int id);
        public Task<List<GenreResponseDTO>> GetAll();
        public Task<GenreResponseDTO> GetById(int id);
    }
}
