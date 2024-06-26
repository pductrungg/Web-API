using Dpoint.BackEnd.Checkin.Common.Helppers;

namespace Dpoint.BackEnd.Checkin.Services.Models.Dtos
{
    public class UserCheckInOutDetailLastWeekDto
    {
        public DateTime Date { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double TotalWorkTime
        {
            get
            {
                return Math.Round(UserCheckInOutHelppers.CalculateWorkingTime(CheckIn.TimeOfDay, CheckOut.TimeOfDay) / 60, 1);
            }
        }
    }
}
