using Dpoint.BackEnd.Checkin.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dpoint.BackEnd.Checkin.Api.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var result = await _todoService.Get();
            return Ok(result);
        }
    }
}
