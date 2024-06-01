using BookShop.Persistence.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Persistence.DTOs.AuthorDTO;

namespace BookShop.Services.Contract
{
    public interface IAuthorService
    {
        public Task<ResultDTO> Add(AuthorRequestDTO added);
        public Task<ResultDTO> Update(AuthorResponseDTO updated);
        public Task<ResultDTO> Delete(int id);
        public Task<List<AuthorResponseDTO>> GetAll();
        public Task<AuthorResponseDTO> GetById(int id);
    }
}
