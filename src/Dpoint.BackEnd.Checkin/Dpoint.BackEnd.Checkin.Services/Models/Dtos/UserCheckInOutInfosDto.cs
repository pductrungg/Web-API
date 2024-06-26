using Dpoint.BackEnd.Checkin.Common.Enums;
using Dpoint.BackEnd.Checkin.Common.Helppers;

namespace Dpoint.BackEnd.Checkin.Services.Models.Dtos
{
    public class UserCheckInOutInfosDto
    {
        public DateTime Date { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double LeaveHours { get; set; }
        public IList<AttendanceStatus> Statuses
        {
            get
            {
                var result = new List<AttendanceStatus>();
                double WorkingTime = UserCheckInOutHelppers.CalculateWorkingTime(CheckIn.TimeOfDay, CheckOut.TimeOfDay);

                if (UserCheckInOutHelppers.CheckLateCheckIn(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours))
                {
                    result.Add(AttendanceStatus.LateCheckIn);
                }

                if (UserCheckInOutHelppers.CheckEarlyCheckOut(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours))
                {
                    result.Add(AttendanceStatus.EarlyCheckOut);
                }

                if (UserCheckInOutHelppers.CheckForgetCheckIn(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours))
                {
                    result.Add(AttendanceStatus.ForgetCheckIn);
                }

                if (UserCheckInOutHelppers.CheckForgetCheckOut(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours))
                {
                    result.Add(AttendanceStatus.ForgetCheckOut);
                }

                if (UserCheckInOutHelppers.CheckAbsent(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours))
                {
                    if (LeaveHours > 0) result.Add(AttendanceStatus.LeaveOfAbsence);
                    else
                    {
                        if (CheckIn.TimeOfDay == CheckOut.TimeOfDay) result.Add(AttendanceStatus.DayOff);
                        else result.Add(AttendanceStatus.Absent);
                    }
                }

                if (UserCheckInOutHelppers.CheckMissingTime(CheckIn.TimeOfDay, CheckOut.TimeOfDay, WorkingTime, LeaveHours))
                {
                    result.Add(AttendanceStatus.MissingTime);
                }

                if (WorkingTime >= UserCheckInOutHelppers.TotalTimeWork)
                {
                    result.Add(AttendanceStatus.Normal);
                }

                if (!result.Any())
                {
                    result.Add(AttendanceStatus.DayOff);
                }
                return result;
            }

        }

    }
}
