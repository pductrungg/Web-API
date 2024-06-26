using Dpoint.BackEnd.Checkin.Common.Commons;
using Dpoint.BackEnd.Checkin.Services.Models.Dtos;
using Dpoint.BackEnd.Checkin.Services.Models.Requests;

namespace Dpoint.BackEnd.Checkin.Services.Interfaces
{
    public interface IUserCheckinService
    {
        public Task<AppActionResultData<List<UserInfoDto>>> GetUserByNameAsync(UserInfoRequest request);

        public Task<AppActionResultData<UserCheckInOutReportDto>> GetUserAttendanceReportAsync(UserCheckInOutRequest request);
        public Task<AppActionResultData<List<UserCheckInOutInfosDto>>> GetUserAttendanceInfosAsync(UserCheckInOutRequest request);
        public Task<AppActionResultData<List<UserCheckInOutDetailDto>>> GetUserAttendanceDetailAsync(UserCheckInOutRequest request);
        public Task<AppActionResultData<List<UserCheckInOutDetailLastWeekDto>>> GetUserAttendanceDetailLastWeekAsync(int userId);
        public Task<AppActionResultData<List<RelationDepartmentDto>>> GetDepartmentInfoAsync();
    }
}
