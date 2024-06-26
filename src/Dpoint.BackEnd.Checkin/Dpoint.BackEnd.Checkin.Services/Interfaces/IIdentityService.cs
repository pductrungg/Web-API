using Dpoint.BackEnd.Checkin.Common.Commons;
using Dpoint.BackEnd.Checkin.Services.Models.Dtos;
using Dpoint.BackEnd.Checkin.Services.Models.Requests;


namespace Dpoint.BackEnd.Checkin.Services.Interfaces
{
    public interface IIdentityService   
    {
        public Task<AppActionResultData<UserLoginDto>> GetUserDataAsync(UserLoginRequest request);
    }
}
