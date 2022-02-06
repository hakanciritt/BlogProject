using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
