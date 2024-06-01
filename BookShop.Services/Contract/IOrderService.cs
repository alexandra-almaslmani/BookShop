using BookShop.Persistence.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShop.Persistence.DTOs.OrderDTO;

namespace BookShop.Services.Contract
{
    public interface IOrderService
    {
        public Task<ResultDTO> Add(OrderRequestDTO added);
        public Task<ResultDTO> Update(OrderResponseDTO updated);
        public Task<ResultDTO> Delete(int id);
        public Task<List<OrderResponseDTO>> GetAll();
        public Task<OrderResponseDTO> GetById(int id);
    }
}
