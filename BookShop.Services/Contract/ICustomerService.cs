using BookShop.Persistence.DTOs.BookDTO;
using BookShop.Persistence.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Persistence.DTOs.CustomerDTO;

namespace BookShop.Services.Contract
{
    public interface ICustomerService
    {
        public Task<ResultDTO> Add(CustomerRequestDTO added);
        public Task<ResultDTO> Update(CustomerResponseDTO updated);
        public Task<ResultDTO> Delete(int id);
        public Task<List<CustomerResponseDTO>> GetAll();
        public Task<CustomerResponseDTO> GetById(int id);
    }
}
