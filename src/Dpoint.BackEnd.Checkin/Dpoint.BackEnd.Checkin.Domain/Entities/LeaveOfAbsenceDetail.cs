
using Dpoint.BackEnd.Checkin.Common.Enums;

namespace Dpoint.BackEnd.Checkin.Domain.Entities
{
    public class LeaveOfAbsenceDetail
    {
        public int Id { get; set; }
        public int LeaveOfAbsenceId { get; set; }
        public int UserId { get; set; }
        public double LeaveHours { get; set; }
        public DateTime LeaveDate { get; set; }
        public LeaveOfAbsenceStatus Status { get; set; }
        public LeaveOfAbsence LeaveOfAbsence { get; set; }
    }
}
