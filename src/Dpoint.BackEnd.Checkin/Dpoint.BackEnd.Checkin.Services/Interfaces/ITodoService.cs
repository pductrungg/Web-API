using Dpoint.BackEnd.Checkin.Common.Commons;
using Dpoint.BackEnd.Checkin.Services.Models.Dtos;


namespace Dpoint.BackEnd.Checkin.Services.Interfaces
{
    public interface ITodoService
    {
        public Task<AppActionResultData<List<CheckInOutDto>>> Get();
    }
}
