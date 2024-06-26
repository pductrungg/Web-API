using AutoMapper;
using Dpoint.BackEnd.Checkin.Domain.Entities;
using Dpoint.BackEnd.Checkin.Services.Models.Dtos;

namespace Dpoint.BackEnd.Checkin.Services.Models.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Todo, TodoDto>(MemberList.Destination);
            CreateMap<CheckInOut, CheckInOutDto>(MemberList.Destination);
            CreateMap<UserInfo, UserInfoDto>().ForMember(des => des.UserId, act => act.MapFrom(src => src.UserEnrollNumber))
                .ForMember(des => des.FullName, act => act.MapFrom(src => src.UserFullName))
                .ForMember(des => des.Email, act => act.MapFrom(src => src.UserCalledName))
                .ForMember(des => des.DeptId, act => act.MapFrom(src => src.UserIDD))
                ;
            CreateMap<RelationDept, RelationDepartmentDto>(MemberList.Destination);
            CreateMap<LeaveOfAbsence, LeaveOfAbsenceDto>(MemberList.Destination);
            CreateMap<LeaveOfAbsenceDto, LeaveOfAbsence>(MemberList.Destination);
            CreateMap<LeaveOfAbsence, LeaveOfAbsenceBaseDto>(MemberList.Destination);
            CreateMap<OutOfOffice, OutOfOfficeDto>(MemberList.Destination);
        }
    }
}
