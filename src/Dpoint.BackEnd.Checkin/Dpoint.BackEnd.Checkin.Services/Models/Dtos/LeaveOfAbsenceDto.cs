using Dpoint.BackEnd.Checkin.Common.Enums;
using Dpoint.BackEnd.Checkin.Domain.Entities;

namespace Dpoint.BackEnd.Checkin.Services.Models.Dtos
{
    public class LeaveOfAbsenceBaseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTo { get; set; }
        public double TotalLeaveHour { get; set; }
        public string LeaveReason { get; set; }
        public string Note { get; set; }
        public LeaveOfAbsenceStatus Status { get; set; }
    }
    public class LeaveOfAbsenceDto: LeaveOfAbsenceBaseDto
    {        
        public List<LeaveOfAbsenceDetail> LeaveOfAbsenceDetails { get; set; }
    }
    
}
