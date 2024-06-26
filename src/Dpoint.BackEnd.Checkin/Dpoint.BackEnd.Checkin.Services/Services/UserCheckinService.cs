using AutoMapper;
using Dpoint.BackEnd.Checkin.Common.Commons;
using Dpoint.BackEnd.Checkin.Common.Constants;
using Dpoint.BackEnd.Checkin.Common.Enums;
using Dpoint.BackEnd.Checkin.Common.Helppers;
using Dpoint.BackEnd.Checkin.Domain.Contexts;
using Dpoint.BackEnd.Checkin.Domain.Entities;
using Dpoint.BackEnd.Checkin.Services.Interfaces;
using Dpoint.BackEnd.Checkin.Services.Models.Dtos;
using Dpoint.BackEnd.Checkin.Services.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace Dpoint.BackEnd.Checkin.Services.Services
{
    public class UserCheckinService : BaseService, IUserCheckinService
    {
        private IMapper _mapper;
        private IApplicationDbContext _context;

        public UserCheckinService(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<DateFromLeaveAbsenceDto>> GetLeaveOfAbsenceWithDate(int UserId, DateTime FromDateAfterParse, DateTime ToDateAfterParse)
        {
            var result = new List<DateFromLeaveAbsenceDto>();

            var leaveOfAbsenceList = await _context.LeaveOfAbsenceDetails.Where(x => x.UserId == UserId
                                                                                && x.Status == LeaveOfAbsenceStatus.Approved
                                                                                && (FromDateAfterParse <= x.LeaveDate && x.LeaveDate <= ToDateAfterParse))
                                                                                .GroupBy(x => x.LeaveDate)
                                                                                .Select(x => new DateFromLeaveAbsenceDto
                                                                                {
                                                                                    LeaveDate = x.Key,
                                                                                    LeaveHours = x.Sum(x => x.LeaveHours) <= UserCheckInOutHelppers.WorkingHours
                                                                                    ? x.Sum(x => x.LeaveHours) : UserCheckInOutHelppers.WorkingHours,
                                                                                }).ToListAsync();
            if (leaveOfAbsenceList.Any())
            {
                result = leaveOfAbsenceList;
            }

            return result;
        }

        public List<CheckInOut> GetCheckInOutWithCalendar(DateTime startDate, DateTime endDate, List<CheckInOut> data)
        {
            var result = new List<CheckInOut>();
            var listCalendarDate = new List<DateFromCalendarDto>();
            if (endDate > DateTime.Now)
            {
                endDate = DateTime.Now;
            }
            for (int i = 0; i < endDate.Subtract(startDate).TotalDays; i++)
            {
                listCalendarDate.Add(new DateFromCalendarDto
                {
                    Date = startDate.AddDays(i)
                });
            }

            result = listCalendarDate.GroupJoin(data, calendar => calendar.Date, checkin => checkin.TimeDate, (ca, ch) => new { Calendar = ca, Checkin = ch })
                .SelectMany(checkinCalendar => checkinCalendar.Checkin.DefaultIfEmpty(), (calendar, checkin) => new
                {
                    ca = calendar,
                    ch = checkin
                }).Select(x => new CheckInOut
                {
                    TimeDate = x.ca.Calendar.Date,
                    TimeStr = x.ch?.TimeStr ?? x.ca.Calendar.Date
                }).ToList();

            return result;
        }

        public async Task<AppActionResultData<List<UserInfoDto>>> GetUserByNameAsync(UserInfoRequest request)
        {

            var result = new AppActionResultData<List<UserInfoDto>>();

            if (DepartmentCodeConstant.ListDepartmentCodeConstant.Contains(request.DepartmentId))
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_INVALID_DEPARTMENT_DATA);
            }

            var userInfos = _context.UserInfos.Where(x => x.UserIDD != null && !DepartmentCodeConstant.ListDepartmentCodeConstant.Contains((int)x.UserIDD));

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                userInfos = userInfos.Where(x => x.UserIDD == request.DepartmentId && x.UserFullName.Contains(request.Name));
            }
            else
            {
                userInfos = userInfos.Where(x => x.UserIDD == request.DepartmentId).Take(30);
            }

            if (!userInfos.Any())
            {
                return BuildMultilingualError(result, string.Format(MessageResponseConstant.ERROR_DATA_NOT_FOUND, request.Name));
            }

            var userInfoList = await userInfos.ToListAsync();
            var dtoUserInfos = _mapper.Map<List<UserInfo>, List<UserInfoDto>>(userInfoList);

            return BuildMultilingualResult(result, dtoUserInfos, MessageResponseConstant.SUCCESSFULLY);
        }

        public async Task<AppActionResultData<UserCheckInOutReportDto>> GetUserAttendanceReportAsync(UserCheckInOutRequest request)
        {
            var result = new AppActionResultData<UserCheckInOutReportDto>();

            DateTime FromDateAfterParse;
            DateTime ToDateAfterParse;

            var isValidateFromDate = DateTime.TryParse(request.FromDate, out FromDateAfterParse);
            var isValidateToDate = DateTime.TryParse(request.ToDate, out ToDateAfterParse);

            if (!isValidateFromDate || !isValidateToDate)
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_INVALID_DATE_REQUEST);
            }

            var userCheckInOutReports = GetCheckInOutWithCalendar(FromDateAfterParse, ToDateAfterParse, await _context.CheckInOuts.Where(x => x.UserEnrollNumber == request.UserId
                                                                      && x.TimeStr >= FromDateAfterParse
                                                                      && x.TimeStr <= ToDateAfterParse).ToListAsync());


            if (!userCheckInOutReports.Any())
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_DATA_REPORT_NOT_FOUND);
            }

            var dtoUserCheckInOutReport = new UserCheckInOutReportDto();

            var listCheckInOutReport = userCheckInOutReports.GroupBy(x => x.TimeDate).Select(x =>
                                                          new UserCheckInOutReportBaseDto
                                                          {
                                                              CheckIn = x.Select(t => t.TimeStr).Min().TimeOfDay,
                                                              CheckOut = x.Select(t => t.TimeStr).Max().TimeOfDay,
                                                              Date = x.Key,
                                                          }).ToList();

            var listLeaveOfAbsence = await GetLeaveOfAbsenceWithDate(request.UserId, FromDateAfterParse, ToDateAfterParse);

            if (listLeaveOfAbsence.Any())
            {
                foreach (var item in listLeaveOfAbsence)
                {
                    var info = listCheckInOutReport.FirstOrDefault(x => x.Date == item.LeaveDate);
                    if (info != null) info.LeaveHours = item.LeaveHours * 60;
                }
            }

            dtoUserCheckInOutReport.TotalLateCheckInDays = listCheckInOutReport.Count(z => UserCheckInOutHelppers.CheckLateCheckIn(z.CheckIn, z.CheckOut, z.WorkingTime, z.LeaveHours));
            dtoUserCheckInOutReport.TotalEarlyCheckOutDays = listCheckInOutReport.Count(z => UserCheckInOutHelppers.CheckEarlyCheckOut(z.CheckIn, z.CheckOut, z.WorkingTime, z.LeaveHours));
            dtoUserCheckInOutReport.TotalForgetCheckinDays = listCheckInOutReport.Count(z => UserCheckInOutHelppers.CheckForgetCheckIn(z.CheckIn, z.CheckOut, z.WorkingTime, z.LeaveHours));
            dtoUserCheckInOutReport.TotalForgetCheckoutDays = listCheckInOutReport.Count(z => UserCheckInOutHelppers.CheckForgetCheckOut(z.CheckIn, z.CheckOut, z.WorkingTime, z.LeaveHours));
            dtoUserCheckInOutReport.TotalMissingTime = listCheckInOutReport.Sum(z => UserCheckInOutHelppers.CheckMissingTime(z.CheckIn, z.CheckOut, z.WorkingTime, z.LeaveHours)
                                                                                            ? Math.Round(UserCheckInOutHelppers.CalculateMissingTime(z.CheckIn, z.CheckOut, z.WorkingTime, z.LeaveHours) / 60, 1) : 0);


            if (dtoUserCheckInOutReport.TotalMissingTime != 0)
            {
                dtoUserCheckInOutReport.TotalMissingTime = Math.Round(dtoUserCheckInOutReport.TotalMissingTime, 1);
            }

            return BuildMultilingualResult(result, dtoUserCheckInOutReport, MessageResponseConstant.SUCCESSFULLY);
        }

        public async Task<AppActionResultData<List<UserCheckInOutInfosDto>>> GetUserAttendanceInfosAsync(UserCheckInOutRequest request)
        {
            var result = new AppActionResultData<List<UserCheckInOutInfosDto>>();

            DateTime FromDateAfterParse;
            DateTime ToDateAfterParse;

            var isValidateFromDate = DateTime.TryParse(request.FromDate, out FromDateAfterParse);
            var isValidateToDate = DateTime.TryParse(request.ToDate, out ToDateAfterParse);

            if (!isValidateFromDate || !isValidateToDate)
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_INVALID_DATE_REQUEST);
            }

            var userCheckInOutInfos = GetCheckInOutWithCalendar(FromDateAfterParse, ToDateAfterParse, await _context.CheckInOuts.Where(x => x.UserEnrollNumber == request.UserId
                                                                     && x.TimeStr >= FromDateAfterParse
                                                                     && x.TimeStr <= ToDateAfterParse).ToListAsync())
                                                                     .GroupBy(x => x.TimeDate)
                                                                     .Select(x => new UserCheckInOutInfosDto
                                                                     {
                                                                         CheckIn = x.Select(t => t.TimeStr).Min(),
                                                                         CheckOut = x.Select(t => t.TimeStr).Max(),
                                                                         Date = x.Key,
                                                                     }).ToList();

            if (!userCheckInOutInfos.Any())
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_DATA_INFOS_NOT_FOUND);
            }

            var listLeaveOfAbsence = await GetLeaveOfAbsenceWithDate(request.UserId, FromDateAfterParse, ToDateAfterParse);

            if (listLeaveOfAbsence.Any())
            {
                foreach (var item in listLeaveOfAbsence)
                {
                    var info = userCheckInOutInfos.FirstOrDefault(x => x.Date == item.LeaveDate);
                    if (info != null) info.LeaveHours = item.LeaveHours * 60;
                }
            }

            return BuildMultilingualResult(result, userCheckInOutInfos, MessageResponseConstant.SUCCESSFULLY);
        }

        public async Task<AppActionResultData<List<UserCheckInOutDetailDto>>> GetUserAttendanceDetailAsync(UserCheckInOutRequest request)
        {
            var result = new AppActionResultData<List<UserCheckInOutDetailDto>>();

            DateTime FromDateAfterParse;
            DateTime ToDateAfterParse;

            var isValidateFromDate = DateTime.TryParse(request.FromDate, out FromDateAfterParse);
            var isValidateToDate = DateTime.TryParse(request.ToDate, out ToDateAfterParse);

            if (!isValidateFromDate || !isValidateToDate)
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_INVALID_DATE_REQUEST);
            }

            var userCheckInOutDetail = GetCheckInOutWithCalendar(FromDateAfterParse, ToDateAfterParse, await _context.CheckInOuts.Where(x => x.UserEnrollNumber == request.UserId
                                                                    && x.TimeStr >= FromDateAfterParse
                                                                    && x.TimeStr <= ToDateAfterParse).ToListAsync())
                                                                    .GroupBy(x => x.TimeDate)
                                                                    .Select(x => new UserCheckInOutDetailDto
                                                                    {
                                                                        CheckIn = x.Select(t => t.TimeStr).Min(),
                                                                        CheckOut = x.Select(t => t.TimeStr).Max(),
                                                                        Date = x.Key,
                                                                    }).ToList();

            if (!userCheckInOutDetail.Any())
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_DATA_INFOS_NOT_FOUND);
            }

            var listLeaveOfAbsence = await GetLeaveOfAbsenceWithDate(request.UserId, FromDateAfterParse, ToDateAfterParse);

            if (listLeaveOfAbsence.Any())
            {
                foreach (var item in listLeaveOfAbsence)
                {
                    var info = userCheckInOutDetail.FirstOrDefault(x => x.Date == item.LeaveDate);
                    if (info != null) info.LeaveHours = item.LeaveHours * 60;
                }
            }


            return BuildMultilingualResult(result, userCheckInOutDetail, MessageResponseConstant.SUCCESSFULLY);
        }

        public async Task<AppActionResultData<List<UserCheckInOutDetailLastWeekDto>>> GetUserAttendanceDetailLastWeekAsync(int userId)
        {
            var result = new AppActionResultData<List<UserCheckInOutDetailLastWeekDto>>();

            DayOfWeek weekStart = DayOfWeek.Monday;
            DateTime startingDate = DateTime.Today;

            while (startingDate.DayOfWeek != weekStart)
                startingDate = startingDate.AddDays(-1);

            DateTime previousWeekStart = startingDate.AddDays(-7);
            //DateTime previousWeekEnd = startingDate.AddDays(-1);
            DateTime thisWeekStart = startingDate;

            var userCheckInOutDetailLastWeek = GetCheckInOutWithCalendar(previousWeekStart, thisWeekStart, await _context.CheckInOuts.Where(x => x.UserEnrollNumber == userId
                                                                    && x.TimeStr >= previousWeekStart
                                                                    && x.TimeStr < thisWeekStart).ToListAsync())
                                                                    .GroupBy(x => x.TimeDate)
                                                                    .Select(x => new UserCheckInOutDetailLastWeekDto
                                                                    {
                                                                        CheckIn = x.Select(t => t.TimeStr).Min(),
                                                                        CheckOut = x.Select(t => t.TimeStr).Max(),
                                                                        Date = x.Key,
                                                                    }).ToList();


            if (!userCheckInOutDetailLastWeek.Any())
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_DATA_DETAIL_LASTWEEK_NOT_FOUND);
            }

            return BuildMultilingualResult(result, userCheckInOutDetailLastWeek, MessageResponseConstant.SUCCESSFULLY);
        }

        public async Task<AppActionResultData<List<RelationDepartmentDto>>> GetDepartmentInfoAsync()
        {
            var result = new AppActionResultData<List<RelationDepartmentDto>>();

            var departmentInfos = await _context.RelationDepts.Where(x => !DepartmentCodeConstant.ListDepartmentCodeConstant.Contains(x.ID)).ToListAsync();

            if (!departmentInfos.Any())
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_DATA_DEPARTMENT_NOT_FOUND);
            }

            var dtoDepartmentInfos = _mapper.Map<List<RelationDept>, List<RelationDepartmentDto>>(departmentInfos);

            return BuildMultilingualResult(result, dtoDepartmentInfos, MessageResponseConstant.SUCCESSFULLY);
        }
    }
}
