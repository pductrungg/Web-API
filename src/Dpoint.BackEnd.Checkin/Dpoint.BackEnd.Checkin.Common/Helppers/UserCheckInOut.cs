
namespace Dpoint.BackEnd.Checkin.Common.Helppers
{
    public static class UserCheckInOutHelppers
    {
        // time start work
        public static readonly TimeSpan FirstStartTime = new TimeSpan(8, 30, 59);
        public static readonly TimeSpan LastStartTime = new TimeSpan(10, 0, 59);

        // time break
        public static readonly TimeSpan StartTimeBreak = new TimeSpan(12, 0, 59);
        public static readonly TimeSpan EndTimeBreak = new TimeSpan(13, 0, 59);

        // time finish work
        public static readonly TimeSpan FirstEndTime = new TimeSpan(17, 30, 59);
        public static readonly TimeSpan LastEndTime = new TimeSpan(19, 0, 59);

        public static readonly TimeSpan TimeDuration = new TimeSpan(0, 30, 0);
        public static readonly double TotalTimeWork = 480;   // 8h   
        public static readonly double RangeCheck = 30;   // 30 minutes check late checkin, forget checkin, early checkout, forget checkout
        public static readonly double MorningWorkingTime = 180;   // 3h
        public static readonly double AfternoonWorkingTime = 300;  // 5h
        public static readonly double WorkingHours = 8;
        // working time if off
        public static readonly TimeSpan StartTimeNine = new TimeSpan(9, 0, 59);
        public static readonly TimeSpan EndTimeEighteen = new TimeSpan(18, 0, 0);

        public static double CalculateWorkingTime(TimeSpan checkIn, TimeSpan checkOut)
        {
            TimeSpan Start;
            TimeSpan End;
            double calWorkingTime;

            //check start work time
            if (checkIn < FirstStartTime && checkOut > FirstStartTime)
            {
                Start = FirstStartTime;
            }
            else if (checkIn > StartTimeBreak && checkIn < EndTimeBreak)
            {
                Start = EndTimeBreak;
            }
            else
            {
                Start = checkIn;
            }
            //check end work time
            if (checkOut > LastEndTime)
            {
                End = LastEndTime;
            }
            else if (checkOut > StartTimeBreak && checkOut < EndTimeBreak)
            {
                End = StartTimeBreak;
            }
            else
            {
                End = checkOut;
            }

            //calculate working time
            if (Start == End)
            {
                calWorkingTime = 0;
            }
            else if (Start >= EndTimeBreak || End <= StartTimeBreak)
            {
                calWorkingTime = (End - Start).TotalMinutes;
            }
            else
            {
                calWorkingTime = ((End - Start) - (EndTimeBreak - StartTimeBreak)).TotalMinutes;
            }

            if(calWorkingTime < 0) calWorkingTime = 0;

            return Math.Round(calWorkingTime);
        }

        public static bool CheckLateCheckIn(TimeSpan checkIn, TimeSpan checkOut, double workTime, double leaveHours)
        {
            if (!CheckMissingTime(checkIn, checkOut, workTime, leaveHours))
            {
                return false;
            }

            if (leaveHours > 0)
            {
                double lateTime;

                if (checkIn > StartTimeBreak && checkOut > StartTimeBreak)
                {
                    // checkin > 12h: late checkin when checkin from 10h - 10h30 (exclude leave absence time & time break)
                    lateTime = checkIn.Subtract(LastStartTime).TotalMinutes - leaveHours - (EndTimeBreak - StartTimeBreak).TotalMinutes;
                }
                else if (checkIn < EndTimeBreak && checkOut < EndTimeBreak)
                {
                    // checkout < 13h: late checkin when checkin from 10h - 10h30 
                    lateTime = checkIn.Subtract(LastStartTime).TotalMinutes;
                }
                // normal: late checkin when checkin from 10h - 10h30 (exclude leave absence time)
                else lateTime = checkIn.Subtract(LastStartTime).TotalMinutes - leaveHours;

                return LastStartTime < checkIn && 0 < lateTime && lateTime <= RangeCheck;
            }
            else
            {
                if (checkIn > StartTimeBreak && checkOut > StartTimeBreak)
                {
                    // checkin > 12h: late checkin when checkin from 13h - 13h30
                    return EndTimeBreak < checkIn && checkIn <= (EndTimeBreak + TimeDuration);
                }
                else if (checkIn < EndTimeBreak && checkOut < EndTimeBreak)
                {
                    // checkout < 13h: late checkin when checkin from 9h - 9h30
                    return StartTimeNine < checkIn && checkIn <= (StartTimeNine + TimeDuration);
                }

                // normal: late checkin when checkin from 10h - 10h30
                return LastStartTime < checkIn && checkIn <= (LastStartTime + TimeDuration);
            }
        }
        public static bool CheckEarlyCheckOut(TimeSpan checkIn, TimeSpan checkOut, double workTime, double leaveHours)
        {

            if (!CheckMissingTime(checkIn, checkOut, workTime, leaveHours))
            {
                return false;
            }

            if (leaveHours > 0)
            {
                // normal: early checkout when checkout before 19h && workingtime from 7.5 - 8  (exclude leave absence time)                              
                return LastEndTime.Subtract(checkOut).TotalMinutes >= 1 && workTime >= TotalTimeWork - leaveHours - RangeCheck;
            }
            else
            {
                if (checkIn > StartTimeBreak && checkOut > StartTimeBreak)
                {
                    // checkin > 12h: early checkout when checkout before 18h && working time 4.5 - 5                     
                    return EndTimeEighteen.Subtract(checkOut).TotalMinutes >= 1 && workTime >= AfternoonWorkingTime - RangeCheck;
                }
                else if (checkIn < EndTimeBreak && checkOut < EndTimeBreak)
                {
                    //checkout < 13h: early checkout when checkout before 12h && working time 2.5 - 3                     
                    return StartTimeBreak.Subtract(checkOut).TotalMinutes >= 1 && workTime >= MorningWorkingTime - RangeCheck;
                }

                // normal: early checkout when checkout before 19h && workingtime from 7.5 - 8                 
                return LastEndTime.Subtract(checkOut).TotalMinutes >= 1 && workTime >= TotalTimeWork - RangeCheck;
            }
        }
        public static bool CheckForgetCheckIn(TimeSpan checkIn, TimeSpan checkOut, double workTime, double leaveHours)
        {

            if (!CheckMissingTime(checkIn, checkOut, workTime, leaveHours))
            {
                return false;
            }

            if (leaveHours > 0)
            {
                double lateTime;

                if (checkIn > StartTimeBreak && checkOut > StartTimeBreak)
                {
                    // checkin > 12h: forget checkin when checkin after 10h30 (exclude leave absence time & time break)
                    lateTime = checkIn.Subtract(LastStartTime).TotalMinutes - leaveHours - (EndTimeBreak - StartTimeBreak).TotalMinutes;
                }
                else if (checkIn < EndTimeBreak && checkOut < EndTimeBreak)
                {
                    // checkout < 13h:  forget checkin when checkin after 10h30 (include leave absence time)
                    lateTime = checkIn.Subtract(LastStartTime).TotalMinutes;
                }
                // normal: forget checkin when checkin after 10h30 (exclude leave absence time)
                else lateTime = checkIn.Subtract(LastStartTime).TotalMinutes - leaveHours;

                return lateTime > RangeCheck;
            }
            else
            {
                if (checkIn > StartTimeBreak && checkOut > StartTimeBreak)
                {
                    // checkin > 12h: forget checkin when checkin after 13h30
                    return checkIn > (EndTimeBreak + TimeDuration);
                }
                else if (checkIn < EndTimeBreak && checkOut < EndTimeBreak)
                {
                    // checkout < 13h: forget checkin when checkin after 9h30
                    return checkIn > (StartTimeNine + TimeDuration);
                }

                // normal: forget checkin when checkin after 10h30
                return checkIn > (LastStartTime + TimeDuration);
            }
        }

        public static bool CheckForgetCheckOut(TimeSpan checkIn, TimeSpan checkOut, double workTime, double leaveHours)
        {

            if (!CheckMissingTime(checkIn, checkOut, workTime, leaveHours))
            {
                return false;
            }

            if (leaveHours > 0)
            {
                // normal: forget checkout when checkout before 19h && work time < 7.5   (exclude leave absence time)               
                return LastEndTime.Subtract(checkOut).TotalMinutes >= 1 && workTime < TotalTimeWork - leaveHours - RangeCheck;
                
            }
            else
            {
                if (checkIn > StartTimeBreak && checkOut > StartTimeBreak)
                {
                    // checkin > 12h: forget checkout when checkout before 18h && working time < 4.5                    
                    return EndTimeEighteen.Subtract(checkOut).TotalMinutes >= 1 && workTime < AfternoonWorkingTime - RangeCheck;
                }
                else if (checkIn < EndTimeBreak && checkOut < EndTimeBreak)
                {
                    //checkout < 13h: forget checkout when checkout before 12h && working time < 2.5                      
                    return StartTimeBreak.Subtract(checkOut).TotalMinutes >= 1 && workTime < MorningWorkingTime - RangeCheck;
                }

                // normal: forget checkout when checkout before 19h && work time < 7.5                
                return LastEndTime.Subtract(checkOut).TotalMinutes >= 1 && workTime < TotalTimeWork - RangeCheck;
            }
        }

        public static bool CheckAbsent(TimeSpan checkIn, TimeSpan checkOut, double workTime, double leaveHours)
        {
            return checkIn < EndTimeBreak && checkOut < EndTimeBreak || checkIn > StartTimeBreak && checkOut > StartTimeBreak || leaveHours > 0 || workTime == 0;
        }

        public static bool CheckMissingTime(TimeSpan checkIn, TimeSpan checkOut, double workTime, double leaveHours)
        {
            if (checkIn == checkOut || leaveHours == TotalTimeWork || workTime == 0) return false;

            if (leaveHours > 0)
            {
                return workTime < TotalTimeWork - leaveHours;
            }
            else
            {
                if (checkIn > StartTimeBreak && checkOut > StartTimeBreak)
                {
                    // checkin > 12h: missing time when working time < 5
                    return workTime < AfternoonWorkingTime;
                }
                else if (checkIn < EndTimeBreak && checkOut < EndTimeBreak)
                {
                    //checkout < 13h: missing time when working time < 3
                    return workTime < MorningWorkingTime;
                }
            }
            // normal: missing time when working time < 8
            return workTime < TotalTimeWork;
        }

        public static double CalculateLateCheckIn(TimeSpan checkIn, TimeSpan checkOut, double leaveHours)
        {
            if (leaveHours > 0)
            {
                double lateTime;

                if (checkIn > StartTimeBreak && checkOut > StartTimeBreak)
                {
                    // checkin > 12h: late checkin when checkin from 10h - 10h30 (exclude leave absence time & time break)
                    lateTime = checkIn.Subtract(LastStartTime).TotalMinutes - leaveHours - (EndTimeBreak - StartTimeBreak).TotalMinutes;
                }
                else if (checkIn < EndTimeBreak && checkOut < EndTimeBreak)
                {
                    // checkout < 13h: late checkin when checkin from 10h - 10h30 (include leave absence time)
                    lateTime = checkIn.Subtract(LastStartTime).TotalMinutes;
                }
                // normal: late checkin when checkin from 10h - 10h30 (exclude leave absence time)
                else lateTime = checkIn.Subtract(LastStartTime).TotalMinutes - leaveHours;

                return Math.Round(lateTime);
            }
            else
            {
                if (checkIn > StartTimeBreak && checkOut > StartTimeBreak)
                {
                    // checkin > 12h: late checkin when checkin from 13h - 13h30
                    return Math.Round((checkIn - EndTimeBreak).TotalMinutes);
                }
                else if (checkOut < EndTimeBreak && checkOut < EndTimeBreak)
                {
                    // checkout < 13h: late checkin when checkin from 9h - 9h30
                    return Math.Round((checkIn - StartTimeNine).TotalMinutes);
                }

                // normal: late checkin when checkin from 10h - 10h30
                return Math.Round((checkIn - LastStartTime).TotalMinutes);
            }
        }

        public static double CalculateEarlyCheckOut(TimeSpan checkIn, TimeSpan checkOut, double workTime, double leaveHours)
        {
            double lateTime;

            if (CheckLateCheckIn(checkIn, checkOut, workTime, leaveHours))
            {
                lateTime = CalculateLateCheckIn(checkIn, checkOut, leaveHours);
            }
            else lateTime = 0;

            if (leaveHours > 0)
            { 
                return Math.Round(TotalTimeWork - leaveHours - workTime - lateTime);
            }
            else
            {
                if (checkIn > StartTimeBreak && checkOut > StartTimeBreak)
                {
                    // checkin > 12h: early checkout when checkout before 18h && working time 4.5 - 5  
                    return Math.Round(AfternoonWorkingTime - workTime - lateTime);
                }
                else if (checkOut < EndTimeBreak && checkOut < EndTimeBreak)
                {
                    // checkout < 13h: early checkout when checkout before 12h && working time 2.5 - 3 
                    return Math.Round(MorningWorkingTime - workTime - lateTime);
                }

                // normal: early checkout when checkout before 19h && workingtime from 7.5 - 8 
                return Math.Round(TotalTimeWork - workTime - lateTime);
            }
        }

        public static double CalculateMissingTime(TimeSpan checkIn, TimeSpan checkOut, double workTime, double leaveHours)
        {

            double absentTime = CalculateAbsentTime(checkIn, checkOut, workTime, leaveHours);

            return (TotalTimeWork - absentTime - workTime);
        }

        public static double CalculateAbsentTime(TimeSpan checkIn, TimeSpan checkOut, double workTime, double leaveHours)
        {
            double absentTime;
           
            if (leaveHours == TotalTimeWork || checkIn == checkOut || workTime == 0) absentTime = TotalTimeWork;
            else
            {
                if (leaveHours > 0) absentTime = leaveHours;
                else
                {
                    if (checkIn > StartTimeBreak && checkOut > StartTimeBreak)
                    {
                        absentTime = MorningWorkingTime;
                    }
                    else if (checkIn < EndTimeBreak && checkOut < EndTimeBreak && checkOut > FirstStartTime)
                    {
                        absentTime = AfternoonWorkingTime;
                    }
                    else
                    {
                        // normal:
                        absentTime = 0;
                    }
                }
            }

            return absentTime;
        }
    }
}
