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
using BookShop.Persistence.DTOs.OrderDTO;

namespace BookShop.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _repository;
        private readonly IMapper _mapper;
        public OrderService(IRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<ResultDTO> IOrderService.Add(OrderRequestDTO added)
        {
            try
            {
                var order = _mapper.Map<Order>(added);
                var result = await _repository.AddAsync(order);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResultDTO> IOrderService.Delete(int id)
        {
            try
            {
                var order = await _repository.GetByIdAsync(id);
                if (order != null)
                {
                    var result = await _repository.DeleteAsync(id);
                    return result;
                }
                return new ResultDTO { Succeeded = false, Message = "Order not found." };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        async Task<List<OrderResponseDTO>> IOrderService.GetAll()
        {
            try
            {
                var orders = await _repository.GetAllAsync();
                var dtoOrderList = orders.Select(order => _mapper.Map<OrderResponseDTO>(order));
                return dtoOrderList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<OrderResponseDTO> IOrderService.GetById(int id)
        {
            try
            {
                var order = await _repository.GetByIdAsync(id);
                if (order != null)
                {
                    var dtoOrder = _mapper.Map<OrderResponseDTO>(order);
                    return dtoOrder;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResultDTO> IOrderService.Update(OrderResponseDTO updated)
        {
            try
            {
                var order = await _repository.GetByIdAsync(updated.Id);
                if (order == null)
                {
                    return new ResultDTO { Succeeded = false, Message = "Order not found." };
                }
                order.CustomerId = updated.CustomerId;
                var result = await _repository.UpdateAsync(order);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
