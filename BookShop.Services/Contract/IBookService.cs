using BookShop.Persistence.DTOs;
using BookShop.Persistence.DTOs.BookDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Services.Contract
{
    public interface IBookService
    {
        public Task<ResultDTO> Add(BookRequestDTO added);
        public Task<ResultDTO> Update(BookResponseDTO updated);
        public Task<ResultDTO> Delete(int id);
        public Task<List<BookResponseDTO>> GetAll();
        public Task<BookResponseDTO> GetById(int id);
    }
}
