using Dpoint.BackEnd.Checkin.Common.Commons;
using Dpoint.BackEnd.Checkin.Services.Models.Dtos;
using Dpoint.BackEnd.Checkin.Services.Models.Requests;

namespace Dpoint.BackEnd.Checkin.Services.Interfaces
{
    public interface IGetOutOfOffice
    {
        // public Task<AppActionResultData<string>> PostUserLeaveOfAbsenceAsync(UserLeaveRequest request);
        // public Task<AppActionResultData<List<LeaveOfAbsenceBaseDto>>> GetUserLeaveOfAbsenceAsync(UserCheckInOutRequest request);
        // public Task<AppActionResultData<LeaveOfAbsenceBaseDto>> UpdateStatusLeaveOfAbsenceAsync(StatusLeaveAbsenceRequest request);
        public Task<AppActionResultData<string>> PostUserOutOfOfficeAsync(OutOfOfficeRequest request);
        // public Task<AppActionResultData<List<OutOfOfficeDto>>> GetUserOutOfOfficeAsync(UserOutOfOfficeRequest request);


    }
}
