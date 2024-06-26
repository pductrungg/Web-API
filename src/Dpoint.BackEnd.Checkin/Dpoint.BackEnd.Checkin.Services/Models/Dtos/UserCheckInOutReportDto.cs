

using Dpoint.BackEnd.Checkin.Common.Helppers;

namespace Dpoint.BackEnd.Checkin.Services.Models.Dtos
{
    public class UserCheckInOutReportDto
    {
        public int TotalLateCheckInDays { get; set; }
        public int TotalEarlyCheckOutDays { get; set; }
        public int TotalForgetCheckinDays { get; set; }
        public int TotalForgetCheckoutDays { get; set; }
        public double TotalMissingTime { get; set; }

    }

    public class UserCheckInOutReportBaseDto
    {
        public DateTime Date { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan CheckOut { get; set; }
        public double LeaveHours { get; set; }
        public double WorkingTime => UserCheckInOutHelppers.CalculateWorkingTime(CheckIn, CheckOut);

    }
}
