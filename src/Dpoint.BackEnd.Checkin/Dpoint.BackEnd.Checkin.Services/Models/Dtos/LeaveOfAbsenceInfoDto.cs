
namespace Dpoint.BackEnd.Checkin.Services.Models.Dtos
{
    public class LeaveOfAbsenceInfoDto
    {
        public string UserFullName { get; set; }
        public string AmisEmployeeCode { get; set; }
        public string AmisEmail { get; set; }
        public string UserEmployeeCode { get; set; }
        public string UserEmail { get; set; }
        public string AmisDeptCode { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTo { get; set; }
        public double TotalLeaveHour { get; set; }
        public string LeaveReason { get; set; }
        public string Note { get; set; }
    }
}
