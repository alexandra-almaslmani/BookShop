using AutoMapper;
using BookShop.Persistence.DTOs;
using BookShop.Persistence.DTOs.BookDTO;
using BookShop.Persistence.DTOs.CustomerDTO;
using BookShop.Persistence.Entities;
using BookShop.Persistence.IRepositories;
using BookShop.Services.Contract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private IRepository<Customer> _repository;
        private readonly IMapper _mapper;
        public CustomerService(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<ResultDTO> ICustomerService.Add(CustomerRequestDTO added)
        {
            try
            {
                var customer = _mapper.Map<Customer>(added);
                var result = await _repository.AddAsync(customer);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResultDTO> ICustomerService.Delete(int id)
        {
            try
            {
                var customer = await _repository.GetByIdAsync(id);
                if (customer != null)
                {
                    var result = await _repository.DeleteAsync(id);
                    return result;
                }
                return new ResultDTO { Succeeded = false, Message = "Customer not found." };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<List<CustomerResponseDTO>> ICustomerService.GetAll()
        {
            try
            {
                var cusotmers = await _repository.GetAllAsync();
                var dtoCustomerList = cusotmers.Select(cusotmer => _mapper.Map<CustomerResponseDTO>(cusotmer));
                return dtoCustomerList.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<CustomerResponseDTO> ICustomerService.GetById(int id)
        {
            try
            {
                var customer = await _repository.GetByIdAsync(id);
                if (customer != null)
                {
                    var dtoCustomer = _mapper.Map<CustomerResponseDTO>(customer);
                    return dtoCustomer;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        async Task<ResultDTO> ICustomerService.Update(CustomerResponseDTO updated)
        {
            try
            {
                var customer = await _repository.GetByIdAsync(updated.Id);
                if (customer == null)
                {
                    return new ResultDTO { Succeeded = false, Message = "Customer not found." };
                }
                customer.Name = updated.Name;
                customer.PhoneNumber = updated.PhoneNumber;
                customer.Email = updated.Email;
                customer.PurchaseHistory = updated.PurchaseHistory;
                var result = await _repository.UpdateAsync(customer);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
