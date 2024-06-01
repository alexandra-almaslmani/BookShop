using BookShop.Persistence.DTOs.BookDTO;
using BookShop.Persistence.DTOs.OrderDTO;
using BookShop.Services.Contract;
using BookShop.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(OrderRequestDTO added)
        {
            var result = await _orderService.Add(added);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("Delete{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _orderService.Delete(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<OrderResponseDTO>>> GetAll()
        {
            var result = await _orderService.GetAll();

            if (result.Count != 0)
            {
                return result.ToList();
            }
            return BadRequest("Order List is Empty!");
        }

        [HttpGet("GetById{Id}")]
        public async Task<ActionResult<OrderResponseDTO>> GetById(int Id)
        {
            var result = await _orderService.GetById(Id);

            if (result != null)
            {
                return result;
            }
            return BadRequest("Not Found ! ");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(OrderResponseDTO updated)
        {
            var result = await _orderService.Update(updated);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
