using Dpoint.BackEnd.Checkin.Common.Helppers;

namespace Dpoint.BackEnd.Checkin.Services.Models.Dtos
{
    public class UserCheckInOutDetailDto
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime Date { get; set; }
        public double LeaveHours { get; set; }

        private double WorkingTime => UserCheckInOutHelppers.CalculateWorkingTime(CheckIn.TimeOfDay, CheckOut.TimeOfDay);
        public double LateCheckIn
        {
            get
            {
                double result = 0;
                if (UserCheckInOutHelppers.CheckLateCheckIn(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours))
                {
                    result = UserCheckInOutHelppers.CalculateLateCheckIn(CheckIn.TimeOfDay, CheckOut.TimeOfDay, LeaveHours);

                }
                return result;
            }
        }
        public double EarlyCheckOut
        {
            get
            {
                double result = 0;
                if (UserCheckInOutHelppers.CheckEarlyCheckOut(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours))
                {
                    result = UserCheckInOutHelppers.CalculateEarlyCheckOut(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours);
                }

                return result;
            }
        }
        public double MissingTime
        {
            get
            {
                double result = 0;
                if (UserCheckInOutHelppers.CheckMissingTime(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours))
                {
                    result = Math.Round(UserCheckInOutHelppers.CalculateMissingTime(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours) / 60, 1);
                }
                return result;
            }
        }
        public double Absent
        {
            get
            {
                double result = 0;
                if (UserCheckInOutHelppers.CheckAbsent(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours))
                {
                    result = Math.Round(UserCheckInOutHelppers.CalculateAbsentTime(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours) / 60, 1);
                }
                return result;
            }
        }


    }
}
