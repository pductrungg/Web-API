using Dpoint.BackEnd.Checkin.Common.Enums;

namespace Dpoint.BackEnd.Checkin.Domain.Entities
{
    public class LeaveOfAbsence
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTo { get; set; }
        public double TotalLeaveHour { get; set; }
        public string LeaveReason { get; set; }
        public string Note { get; set; }
        public LeaveOfAbsenceStatus Status { get; set; }
        public IEnumerable<LeaveOfAbsenceDetail> LeaveOfAbsenceDetails { get; set; }
    }
}
