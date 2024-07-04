using BookShop.Persistence.DTOs.BookDTO;
using BookShop.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;

        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(BookRequestDTO added)
        {
            var result = await _bookService.Add(added);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("Delete{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _bookService.Delete(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<BookResponseDTO>>> GetAll()
        {
            var result = await _bookService.GetAll();

            if (result.Count != 0)
            {
                return result.ToList();
            }
            return BadRequest("Book List is Empty!");
        }

        [HttpGet("GetById{Id}")]
        public async Task<ActionResult<BookResponseDTO>> GetById(int Id)
        {
            var result = await _bookService.GetById(Id);

            if (result != null)
            {
                return result;
            }
            return BadRequest("Not Found ! ");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(BookResponseDTO updated)
        {
            var result = await _bookService.Update(updated);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
