using Dpoint.BackEnd.Checkin.Services.Interfaces;
using Dpoint.BackEnd.Checkin.Services.Models.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dpoint.BackEnd.Checkin.Api.Controllers
{
    [Route("api/user-checkin")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserCheckinController : ControllerBase
    {
        private readonly IUserCheckinService _userCheckinService;
        public UserCheckinController(IUserCheckinService userCheckinService)
        {
            _userCheckinService = userCheckinService;
        }

        [HttpPost("get-user-by-name")]
        public async Task<IActionResult> GetUserByNameAsync([FromBody] UserInfoRequest request)
        {
            var result = await _userCheckinService.GetUserByNameAsync(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("get-user-attendance-report")]
        public async Task<IActionResult> GetUserAttendanceReportAsync([FromBody] UserCheckInOutRequest request)
        {
            var result = await _userCheckinService.GetUserAttendanceReportAsync(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("get-user-attendance-info")]
        public async Task<IActionResult> GetUserAttendanceInfosAsync([FromBody] UserCheckInOutRequest request)
        {
            var result = await _userCheckinService.GetUserAttendanceInfosAsync(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("get-user-attendance-detail")]
        public async Task<IActionResult> GetUserAttendanceDetailAsync([FromBody] UserCheckInOutRequest request)
        {
            var result = await _userCheckinService.GetUserAttendanceDetailAsync(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-user-attendance-detail-lastweek")]
        public async Task<IActionResult> GetUserAttendanceDetailLastWeekAsync(int userId)
        {
            var result = await _userCheckinService.GetUserAttendanceDetailLastWeekAsync(userId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-department-info")]
        public async Task<IActionResult> GetDepartmentInfoAsync()
        {
            var result = await _userCheckinService.GetDepartmentInfoAsync();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
