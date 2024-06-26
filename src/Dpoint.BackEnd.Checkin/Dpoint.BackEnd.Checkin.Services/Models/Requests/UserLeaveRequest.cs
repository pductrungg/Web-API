using Dpoint.BackEnd.Checkin.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dpoint.BackEnd.Checkin.Services.Models.Requests
{
    public class UserLeaveRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int DeptId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string LeaveFrom { get; set; }
        [Required]
        public string LeaveTo { get; set; }
        [Required]
        public double TotalLeaveHour { get; set; }
        [Required]
        public string LeaveReason { get; set; }
        public string Note { get; set; }
        [Required]
        public List<LeaveOfAbsenceDetailRequest> LeaveOfAbsenceDetails { get; set; }
    }

    public class StatusLeaveAbsenceRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public LeaveOfAbsenceStatus Status { get; set; }
    }

    public class LeaveOfAbsenceDetailRequest
    {
        public int UserId { get; set; }
        public double LeaveHours { get; set; }
        public string LeaveDate { get; set; }
    }
}