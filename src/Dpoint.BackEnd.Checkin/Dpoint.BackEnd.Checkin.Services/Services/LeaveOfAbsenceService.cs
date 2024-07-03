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
using Dpoint.BackEnd.Checkin.Services.Models.Responses;
using Dpoint.BackEnd.Checkin.Services.Models.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Dpoint.BackEnd.Checkin.Services.Services
{
    public class LeaveOfAbsenceService : BaseService, ILeaveOfAbsenceService
    {
        private IMapper _mapper;
        private ApplicationDbContext _context;
        private readonly AppSettings _appSettingsAccessor;

        public LeaveOfAbsenceService(IMapper mapper, ApplicationDbContext context, IOptions<AppSettings> appSettingsAccessor)
        {
            _mapper = mapper;
            _context = context;
            _appSettingsAccessor = appSettingsAccessor.Value;
        }

        public async Task<AppActionResultData<string>> PostUserLeaveOfAbsenceAsync(UserLeaveRequest request)
        {
            var result = new AppActionResultData<string>();
            string processExecutionID = "";

            if (!request.LeaveFrom.TryParseDateTime(out DateTime leaveFrom, DateTimeHelper.DEFAULT_DATETIME_FORMAT))
            {
                return result.BuildError($"Can not convert {nameof(request.LeaveFrom)}");
            }




            if (!request.LeaveTo.TryParseDateTime(out DateTime leaveTo, DateTimeHelper.DEFAULT_DATETIME_FORMAT))
            {
                return result.BuildError($"Can not convert {nameof(request.LeaveTo)}");
            }

            var dtoLeaveOfAbsenceInfo = new LeaveOfAbsenceInfoDto
            {
                LeaveFrom = leaveFrom,
                LeaveTo = leaveTo,
                TotalLeaveHour = request.TotalLeaveHour,
                LeaveReason = request.LeaveReason,
                Note = request.Note ?? "",
            };

            try
            {
                var userInfos = await _context.UserInfos.Where(x => x.UserEnrollNumber.Equals(request.UserId)).FirstOrDefaultAsync();

                if (userInfos != null)
                {
                    dtoLeaveOfAbsenceInfo.UserFullName = userInfos.UserFullName;
                    dtoLeaveOfAbsenceInfo.UserEmail = userInfos.UserCalledName;
                }
                else
                {
                    throw new Exception(MessageResponseConstant.ERROR_DATA_USER_NOT_FOUND);
                }

                var amisDepartment = await _context.AmisDepartments.Where(x => x.InternalDeptId == request.DeptId).FirstOrDefaultAsync();
                if (amisDepartment != null)
                {
                    dtoLeaveOfAbsenceInfo.AmisDeptCode = amisDepartment.AmisDeptCode;
                }
                else
                {
                    throw new Exception(MessageResponseConstant.ERROR_INVALID_DEPARTMENT_DATA);
                }

                var amisEmployee = await _context.AmisEmployees.FirstOrDefaultAsync(x => !x.IsDeleted && x.UserEmail == request.Email);
                if (amisEmployee != null)
                {
                    if (amisEmployee.IsAmisUser)
                    {
                        dtoLeaveOfAbsenceInfo.AmisEmail = amisEmployee.AmisEmail;
                        dtoLeaveOfAbsenceInfo.AmisEmployeeCode = amisEmployee.AmisEmployeeCode;
                    }
                    else
                    {
                        dtoLeaveOfAbsenceInfo.AmisEmail = amisDepartment.AmisDeptEmail;
                        dtoLeaveOfAbsenceInfo.AmisEmployeeCode = amisDepartment.AmisDeptEmployeeCode;
                    }
                    dtoLeaveOfAbsenceInfo.UserEmployeeCode = amisEmployee.AmisEmployeeCode;
                }
                else
                {
                    throw new Exception(MessageResponseConstant.ERROR_INVALID_AMIS_USER_DATA);
                }
            }
            catch (Exception ex)
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_LEAVE_REGISTRATION_FAILED, ex);
            }

            var dataPost = new
            {
                ProcessID = AmisProcessConstant.LQ_PROCESS_ID,
                CreatorEmployeeCode = dtoLeaveOfAbsenceInfo.AmisEmployeeCode,
                CreatorEmail = dtoLeaveOfAbsenceInfo.AmisEmail,
                Data = new ArrayList() {
                                new {
                                      InputCode = AmisProcessConstant.LQ_DEPARTMENT_CODE,
                                      InputValue = new ArrayList(){ new { OrganizationUnitCode = dtoLeaveOfAbsenceInfo.AmisDeptCode} }
                                },
                                new {
                                      InputCode = AmisProcessConstant.LQ_LEAVE_FROM_CODE,
                                      InputValue = new ArrayList(){ new { Value = dtoLeaveOfAbsenceInfo.LeaveFrom} }
                                },
                                new {
                                      InputCode = AmisProcessConstant.LQ_LEAVE_TO_CODE,
                                      InputValue = new ArrayList() { new { Value = dtoLeaveOfAbsenceInfo.LeaveTo } }
                                },
                                new {
                                      InputCode = AmisProcessConstant.LQ_REPLACEMENT_PERSONEL_CODE,
                                      InputValue = new ArrayList() { new { EmployeeCode = "", Email = ""} }
                                },
                                                               new {
                                      InputCode = AmisProcessConstant.LQ_TOTAL_LEAVE_HOUR_CODE,
                                      InputValue = new ArrayList() { new { Value = dtoLeaveOfAbsenceInfo.TotalLeaveHour } }
                                },
                                new {
                                      InputCode = AmisProcessConstant.LQ_NOTE_CODE,
                                      InputValue = new ArrayList() { new { Value = dtoLeaveOfAbsenceInfo.Note } }
                                },
                                new {
                                      InputCode = AmisProcessConstant.LQ_LEAVE_REASON_CODE,
                                      InputValue = new ArrayList() { new { Value = dtoLeaveOfAbsenceInfo.LeaveReason } }
                                },
                                 new {
                                      InputCode = AmisProcessConstant.LQ_EMPLOYEE_NAME_CODE,
                                      InputValue = new ArrayList() { new { EmployeeCode = dtoLeaveOfAbsenceInfo.UserEmployeeCode, Email = dtoLeaveOfAbsenceInfo.UserEmail} }
                                }
                            }
            };

            // Set up HttpClient request to Post data to AMIS Process API            
            string ContentType = _appSettingsAccessor.AmisProcessSettings.ContentType;
            string XClientid = _appSettingsAccessor.AmisProcessSettings.XClientid;
            string TenantID = _appSettingsAccessor.AmisProcessSettings.TenantID;

            var contentPost = JsonSerializer.Serialize(dataPost);

            HttpClient client = new HttpClient();

            var AmisProcessAPIUrl = _appSettingsAccessor.AmisProcessSettings.AmisProcessUrl + _appSettingsAccessor.AmisProcessSettings.AmisProcessEndPoint;
            var httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri(AmisProcessAPIUrl),
                Method = HttpMethod.Post,
                Headers = {
                                { "x-clientid", XClientid },
                                { "TenantID", TenantID }
                            },
                Content = new StringContent(contentPost, Encoding.UTF8)
            };
            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(ContentType);

            // Get data response
            try
            {
                var response = await client.SendAsync(httpRequestMessage);
                if (response.IsSuccessStatusCode)
                {
                    var dtoLeaveOfAbsenceResponse = response.Content.ReadAsAsync<LeaveOfAbsenceResponse>().Result;
                    if (dtoLeaveOfAbsenceResponse != null)
                    {
                        if (dtoLeaveOfAbsenceResponse.Success)
                        {
                            var dataProcessExecution = dtoLeaveOfAbsenceResponse.Data?.FirstOrDefault()?.Data?.ProcessExecution?.ProcessExecutionID;
                            if (dataProcessExecution != null)
                            {
                                processExecutionID = dataProcessExecution;

                                var leaveofAbsenceDetails = new List<LeaveOfAbsenceDetail>();

                                foreach (var item in request.LeaveOfAbsenceDetails)
                                {
                                    if (!item.LeaveDate.TryParseDateTime(out DateTime leaveDate, DateTimeHelper.DEFAULT_DATETIME_FORMAT))
                                    {
                                        return result.BuildError($"Can not convert {nameof(item.LeaveDate)}");
                                    }

                                    leaveofAbsenceDetails.Add(new LeaveOfAbsenceDetail
                                    {
                                        UserId = item.UserId,
                                        LeaveHours = item.LeaveHours,
                                        LeaveDate = leaveDate,
                                        Status = LeaveOfAbsenceStatus.Approved
                                    });
                                }

                                var dtoLeaveOfAbsence = new LeaveOfAbsenceDto
                                {
                                    UserId = request.UserId,
                                    LeaveFrom = leaveFrom,
                                    LeaveTo = leaveTo,
                                    TotalLeaveHour = request.TotalLeaveHour,
                                    LeaveReason = request.LeaveReason,
                                    Note = request.Note,
                                    Status = LeaveOfAbsenceStatus.Approved,
                                    LeaveOfAbsenceDetails = leaveofAbsenceDetails

                                };

                                var dbResult = _mapper.Map<LeaveOfAbsenceDto, LeaveOfAbsence>(dtoLeaveOfAbsence);
                                await _context.LeaveOfAbsences.AddAsync(dbResult);
                                await _context.SaveChangesAsync();
                            }
                            else
                            {
                                throw new Exception("No data returned from Amis!");
                            }
                        }
                        else if (dtoLeaveOfAbsenceResponse.Code == 99)
                        {
                            string errorText = "ERROR: ";
                            if (dtoLeaveOfAbsenceResponse.UserMessage != null) errorText += dtoLeaveOfAbsenceResponse.UserMessage;
                            if (dtoLeaveOfAbsenceResponse.SystemMessage != null) errorText += dtoLeaveOfAbsenceResponse.SystemMessage;
                            throw new Exception(errorText);
                        }
                        else
                        {
                            throw new Exception("POST DATA FAILED!");
                        }
                    }
                    else
                    {
                        throw new Exception("POST DATA FAILED!");
                    }
                }
                else
                {
                    throw new Exception("POST DATA FAILED!");
                }
            }
            catch (Exception ex)
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_LEAVE_REGISTRATION_FAILED, ex);
            }

            return BuildMultilingualResult(result, processExecutionID, MessageResponseConstant.SUCCESSFULLY_REGISTERED_LEAVE);
        }

        public async Task<AppActionResultData<List<LeaveOfAbsenceBaseDto>>> GetUserLeaveOfAbsenceAsync(UserCheckInOutRequest request)
        {
            var result = new AppActionResultData<List<LeaveOfAbsenceBaseDto>>();

            DateTime FromDateAfterParse;
            DateTime ToDateAfterParse;

            var isValidateFromDate = DateTime.TryParse(request.FromDate, out FromDateAfterParse);
            var isValidateToDate = DateTime.TryParse(request.ToDate, out ToDateAfterParse);

            if (!isValidateFromDate || !isValidateToDate)
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_INVALID_DATE_REQUEST);
            }

            var leaveOfAbsenceList = await _context.LeaveOfAbsences.Where(x => x.UserId == request.UserId
                                                                        && ((FromDateAfterParse <= x.LeaveFrom && x.LeaveTo <= ToDateAfterParse) ||
                                                                        (FromDateAfterParse <= x.LeaveFrom && x.LeaveFrom <= ToDateAfterParse) ||
                                                                        (FromDateAfterParse <= x.LeaveTo && x.LeaveTo <= ToDateAfterParse) ||
                                                                        (x.LeaveFrom <= FromDateAfterParse && ToDateAfterParse <= x.LeaveTo)))
                                                                        .ToListAsync();

            /*
            if (!leaveOfAbsenceList.Any())
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_DATA_LEAVE_ABSENCE_NOT_FOUND);
            }
            */

            var dtoLeaveOfAbsence = _mapper.Map<List<LeaveOfAbsence>, List<LeaveOfAbsenceBaseDto>>(leaveOfAbsenceList);

            return BuildMultilingualResult(result, dtoLeaveOfAbsence, MessageResponseConstant.SUCCESSFULLY);
        }

        public async Task<AppActionResultData<LeaveOfAbsenceBaseDto>> UpdateStatusLeaveOfAbsenceAsync(StatusLeaveAbsenceRequest request)
        {
            var result = new AppActionResultData<LeaveOfAbsenceBaseDto>();
            var dtoLeaveOfAbsence = new LeaveOfAbsenceBaseDto();

            try
            {
                var userLeaveOfAbsence = await _context.LeaveOfAbsences.Where(x => x.Id == request.Id && x.UserId == request.UserId).FirstOrDefaultAsync();

                if (userLeaveOfAbsence == null)
                {
                    return BuildMultilingualError(result, MessageResponseConstant.ERROR_DATA_LEAVE_ABSENCE_NOT_FOUND);
                }

                if (userLeaveOfAbsence.Status == request.Status)
                {
                    return BuildMultilingualError(result, MessageResponseConstant.ERROR_INVALID_STATUS);
                }


                var userLeaveOfAbsenceDetails = await _context.LeaveOfAbsenceDetails.Where(x => x.LeaveOfAbsenceId == userLeaveOfAbsence.Id).ToListAsync();

                if (!userLeaveOfAbsenceDetails.Any())
                {
                    return BuildMultilingualError(result, MessageResponseConstant.ERROR_DATA_LEAVE_ABSENCE_NOT_FOUND);
                }

                // update status into DB
                userLeaveOfAbsence.Status = request.Status;

                foreach (var item in userLeaveOfAbsenceDetails)
                {
                    item.Status = userLeaveOfAbsence.Status;
                }

                await _context.SaveChangesAsync();

                dtoLeaveOfAbsence = _mapper.Map<LeaveOfAbsence, LeaveOfAbsenceBaseDto>(userLeaveOfAbsence);

            }
            catch (Exception ex)
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_UPDATE_STATUS_FAILED, ex);
            }

            return BuildMultilingualResult(result, dtoLeaveOfAbsence, MessageResponseConstant.UPDATE_SUCCESSFULLY);
        }
        public async Task<AppActionResultData<string>> PostUserOutOfOfficeAsync(OutOfOfficeRequest request)
        {
            var result = new AppActionResultData<string>();
            var strFrom = request.Date + " " + request.From;
            var strTo = request.Date + " " + request.To;
            if (!strFrom.TryParseDateTime(out DateTime FromDate, DateTimeHelper.DEFAULT_DATETIME_WITHOUT_SECOND_FORMAT))
            {
                return result.BuildError($"Can not convert {nameof(request.Date)}");
            }
            if (!strTo.TryParseDateTime(out DateTime ToDate, DateTimeHelper.DEFAULT_DATETIME_WITHOUT_SECOND_FORMAT))
            {
                return result.BuildError($"Can not convert {nameof(request.Date)}");
            }
            var userInfos = await _context.UserInfos.FirstOrDefaultAsync(x => x.UserEnrollNumber.Equals(request.UserId));
            // if (userInfos == null) return result.BuildError(MessageResponseConstant.ERROR_DATA_USER_NOT_FOUND);

            var newOutOfOffice = new OutOfOfficeDto
            {
                From = FromDate,
                To = ToDate,
                Note = request.Note,
                Reason = request.Reason,
                TotalHour = request.TotalHour,
                UserId = userInfos.UserEnrollNumber,
            };

            // return BuildMultilingualResult(result, MessageResponseConstant.SUCCESSFULLY, MessageResponseConstant.SUCCESSFULLY);

            try{
                var userInfor = await _context.UserInfos.Where(x => x.UserEnrollNumber.Equals(request.UserId)).FirstOrDefaultAsync();
                if(userInfor != null){
                    newOutOfOffice.UserId = userInfos.UserIDD;
                }else{
                    throw new Exception(MessageResponseConstant.ERROR_DATA_USER_NOT_FOUND);
                }

                var amisDepartment = await _context.AmisDepartments.Where(x => x.InternalDeptId == request.DeptId).FirstOrDefaultAsync();
                if(amisDepartment != null){
                    newOutOfOffice.AmisDeptCode = amisDepartment.AmisDeptCode;
                }else{
                    throw new Exception(MessageResponseConstant.ERROR_DATA_DEPARTMENT_NOT_FOUND);
                }

                var amisEmployee = await _context.AmisEmployees.FirstOrDefaultAsync(x => !x.IsDeleted && x.UserEmail == request.Email);
                if(amisEmployee != null){
                    if(amisEmployee.IsAmisUser){
                        newOutOfOffice.AmisEmail =  amisEmployee.AmisEmail;
                        newOutOfOffice.AmisEmployeeCode = amisEmployee.AmisEmployeeCode;
                    }else{
                        newOutOfOffice.AmisEmail = amisDepartment.AmisDeptEmail;
                        newOutOfOffice.AmisEmployeeCode = amisDepartment.AmisDeptEmployeeCode;
                    }
                    newOutOfOffice.UserEmployeeCode = amisEmployee.AmisEmployeeCode;
                }else{
                    throw new Exception(MessageResponseConstant.ERROR_INVALID_AMIS_USER_DATA);
                }
            }catch(Exception ex){
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_LEAVE_REGISTRATION_FAILED, ex);
            }

            var dataPosted = new{
                ProcessID = CF_Constant.CF_PROCESS_ID,
                CreatorEmpCode = newOutOfOffice.AmisEmployeeCode,
                CreatorEmail = newOutOfOffice.AmisEmail,
                Data = new ArrayList(){
                    new{
                        // Input
                        InputCode = AmisProcessConstant.LQ_DEPARTMENT_CODE,
                        InputValue = new ArrayList(){
                            new {
                                OrganizationUnitCode = newOutOfOffice.AmisDeptCode
                            }
                        }
                    },
                    new{
                        InputCode = CF_Constant.CF_FROM,
                        InputValue = new ArrayList(){
                            new{
                                Value = newOutOfOffice.From
                            }
                        }
                    },
                    new{
                        InputCode = CF_Constant.CF_TO,
                        InputValue = new ArrayList(){
                            new{
                                Value = newOutOfOffice.To
                            }
                        } 
                    },
                    new{
                        InputCode = CF_Constant.CF_NOTE,
                        InputValue = new ArrayList(){
                            new{
                                Value = newOutOfOffice.TotalHour
                            }
                        }
                    },
                    new{
                        InputCode = CF_Constant.CF_REASON,
                        InputValue = new ArrayList(){
                            new{
                                Value = newOutOfOffice.Reason
                            }
                        }
                    },
                    new{
                        InputCode = CF_Constant.CF_TOTAL_HOUR,
                        InputValue = new ArrayList(){
                            new{
                                Value = newOutOfOffice.TotalHour
                            }
                        }
                    },
                    new{
                        InputCode = AmisProcessConstant.LQ_EMPLOYEE_NAME_CODE,
                        InputValue = new ArrayList(){
                            new{
                                EmployeeCode = newOutOfOffice.UserEmployeeCode,
                                mail = newOutOfOffice.UserEmail
                            }
                        }
                    }
                }
            };

            string ContentType = _appSettingsAccessor.AmisProcessSettings.ContentType;
            string XClientid = _appSettingsAccessor.AmisProcessSettings.XClientid;
            string TenantID = _appSettingsAccessor.AmisProcessSettings.TenantID;

            var contentPost  = JsonSerializer.Serialize(dataPosted);

            HttpClient client = new HttpClient();

            var AmisProcessAPIUrl = _appSettingsAccessor.AmisProcessSettings.AmisProcessUrl + _appSettingsAccessor.AmisProcessSettings.AmisProcessEndPoint;
            var httpRequestMessage = new HttpRequestMessage(){
                RequestUri = new Uri(AmisProcessAPIUrl),
                Method = HttpMethod.Post,
                Headers = {
                    {"x-clientID",XClientid},
                    {"TenantId",TenantID}
                },
                Content = new StringContent(contentPost, Encoding.UTF8)
            };
            httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(ContentType);

            try{
                // var rep = await .
            }catch{

            }
            return BuildMultilingualResult(result,MessageResponseConstant.SUCCESSFULLY_REGISTERED_LEAVE , MessageResponseConstant.SUCCESSFULLY_REGISTERED_LEAVE);


        }

        public async Task<AppActionResultData<List<OutOfOfficeDto>>> GetUserOutOfOfficeAsync(UserOutOfOfficeRequest request)
        {
            var result = new AppActionResultData<List<OutOfOfficeDto>>();

            DateTime FromDateAfterParse;
            DateTime ToDateAfterParse;

            var isValidateFromDate = DateTime.TryParse(request.FromDate, out FromDateAfterParse);
            var isValidateToDate = DateTime.TryParse(request.ToDate, out ToDateAfterParse);

            if (!isValidateFromDate || !isValidateToDate)
            {
                return BuildMultilingualError(result, MessageResponseConstant.ERROR_INVALID_DATE_REQUEST);
            }

            var outOfOffices = await _context.OutOfOffices.Where(x => x.UserId == request.UserId
                                                                        && ((FromDateAfterParse <= x.From && x.To <= ToDateAfterParse) ||
                                                                        (FromDateAfterParse <= x.From && x.To <= ToDateAfterParse) ||
                                                                        (FromDateAfterParse <= x.From && x.To <= ToDateAfterParse) ||
                                                                        (x.From <= FromDateAfterParse && ToDateAfterParse <= x.To)))
                                                                        .ToListAsync();

           

            var dtoOutOfOffice = _mapper.Map<List<OutOfOffice>, List<OutOfOfficeDto>>(outOfOffices);

            return BuildMultilingualResult(result, dtoOutOfOffice, MessageResponseConstant.SUCCESSFULLY);
        }


    }
}