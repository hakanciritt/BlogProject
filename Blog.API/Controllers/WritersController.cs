using Business.Abstract;
using Dtos.Writer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        private readonly IWriterService _writerService;

        public WritersController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _writerService.GetByIdAsync(id);
            if (result.Success) return Ok(result.Data);
            else return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> Update(WriterUpdateDto writerUpdateDto)
        {
            var result = await _writerService.UpdateAsync(writerUpdateDto);
            if (result.Success) return NoContent();
            return BadRequest();
        }
    }
}
