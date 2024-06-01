using BookShop.Persistence.DTOs.BookDTO;
using BookShop.Persistence.DTOs.GenreDTO;
using BookShop.Persistence.DTOs.OrderDTO;
using BookShop.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add(GenreRequestDTO added)
        {
            var result = await _genreService.Add(added);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpDelete("Delete{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _genreService.Delete(Id);

            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<GenreResponseDTO>>> GetAll()
        {
            var result = await _genreService.GetAll();

            if (result.Count != 0)
            {
                return result.ToList();
            }
            return BadRequest("Genre List is Empty!");
        }

        [HttpGet("GetById{Id}")]
        public async Task<ActionResult<GenreResponseDTO>> GetById(int Id)
        {
            var result = await _genreService.GetById(Id);

            if (result != null)
            {
                return result;
            }
            return BadRequest("Not Found ! ");
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(GenreResponseDTO updated)
        {
            var result = await _genreService.Update(updated);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
