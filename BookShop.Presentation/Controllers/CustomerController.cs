using BookShop.Persistence.DTOs.BookDTO;
using BookShop.Persistence.DTOs.CustomerDTO;
using BookShop.Persistence.DTOs.OrderDTO;
using BookShop.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _cusotmerService;
        public CustomerController(ICustomerService customerService)
        {
            _cusotmerService = customerService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CustomerRequestDTO added)
        {
            var result = await _cusotmerService.Add(added);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("Delete{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _cusotmerService.Delete(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<CustomerResponseDTO>>> GetAll()
        {
            var result = await _cusotmerService.GetAll();
            if (result.Count != 0)
            {
                return result.ToList();
            }
            return BadRequest("Customer List is Empty!");
        }

        [HttpGet("GetById{Id}")]
        public async Task<ActionResult<CustomerResponseDTO>> GetById(int Id)
        {
            var result = await _cusotmerService.GetById(Id);

            if (result != null)
            {
                return result;
            }
            return BadRequest("Not Found ! ");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(CustomerResponseDTO updated)
        {
            var result = await _cusotmerService.Update(updated);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
