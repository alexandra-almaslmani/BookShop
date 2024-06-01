using BookShop.Persistence.DTOs.AuthorDTO;
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
    public class AuthorController : ControllerBase
    {
        private IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(AuthorRequestDTO added)
        {
            var result = await _authorService.Add(added);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("Delete{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _authorService.Delete(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<AuthorResponseDTO>>> GetAll()
        {
            var result = await _authorService.GetAll();

            if (result.Count != 0)
            {
                return result.ToList();
            }
            return BadRequest("Author List is Empty!");
        }

        [HttpGet("GetById{Id}")]
        public async Task<ActionResult<AuthorResponseDTO>> GetById(int Id)
        {
            var result = await _authorService.GetById(Id);

            if (result != null)
            {
                return result;
            }
            return BadRequest("Not Found ! ");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(AuthorResponseDTO updated)
        {
            var result = await _authorService.Update(updated);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
