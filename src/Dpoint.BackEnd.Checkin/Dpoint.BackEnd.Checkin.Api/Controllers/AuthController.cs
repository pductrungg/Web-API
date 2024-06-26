using Dpoint.BackEnd.Checkin.Services.Interfaces;
using Dpoint.BackEnd.Checkin.Services.Models.Requests;
using Microsoft.AspNetCore.Mvc;



namespace Dpoint.BackEnd.Checkin.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("get-user-login-info")]
        public async Task<IActionResult> GetUserDataAsync(UserLoginRequest request)
        {
            var result = await _identityService.GetUserDataAsync(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}


