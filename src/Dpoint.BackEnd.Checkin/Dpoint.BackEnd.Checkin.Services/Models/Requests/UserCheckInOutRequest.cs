namespace Dpoint.BackEnd.Checkin.Services.Models.Requests
{
    public class UserCheckInOutRequest
    {
        public int UserId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }

    public class UserInfoRequest
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }
    public class UserOutOfOfficeRequest
    {
        public int UserId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
