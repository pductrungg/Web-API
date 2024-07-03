using Dpoint.BackEnd.Checkin.Services.Interfaces;
using Dpoint.BackEnd.Checkin.Services.Models.Requests;
using Dpoint.BackEnd.Checkin.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dpoint.BackEnd.Checkin.Api.Controllers
{
    [Route("api/leave-of-absence")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LeaveOfAbsenceController : ControllerBase
    {
        private readonly ILeaveOfAbsenceService _leaveOfAbsenceService;
        public LeaveOfAbsenceController(ILeaveOfAbsenceService leaveOfAbsenceService)
        {
            _leaveOfAbsenceService = leaveOfAbsenceService;
        }

        // private readonly ILeaveOffice _CustomerLeaveForm;
        // public LeaveOfAbsenceController

        [HttpPost("post-leave-of-absence-request")]
        public async Task<IActionResult> PostUserLeaveOfAbsenceAsync([FromBody] UserLeaveRequest request)
        {
            var result = await _leaveOfAbsenceService.PostUserLeaveOfAbsenceAsync(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("post-out-of-office-request")]
        public async Task<IActionResult> PostUserOutOfOfficeAsync([FromBody] OutOfOfficeRequest request)
        {
            var result = await _leaveOfAbsenceService.PostUserOutOfOfficeAsync(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("get-user-leave-of-absence")]
        public async Task<IActionResult> GetUserLeaveOfAbsenceAsync([FromBody] UserCheckInOutRequest request)
        {
            var result = await _leaveOfAbsenceService.GetUserLeaveOfAbsenceAsync(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update-status")]
        public async Task<IActionResult> UpdateStatusLeaveOfAbsenceAsync([FromBody] StatusLeaveAbsenceRequest request)
        {
            var result = await _leaveOfAbsenceService.UpdateStatusLeaveOfAbsenceAsync(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("get-user-out-of-office")]
        public async Task<IActionResult> GetUserOutOfOfficeAsync([FromBody] UserOutOfOfficeRequest request)
        {
            var result = await _leaveOfAbsenceService.GetUserOutOfOfficeAsync(request);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
