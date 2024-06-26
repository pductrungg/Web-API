using Microsoft.AspNetCore.Identity;

namespace Dpoint.BackEnd.Checkin.Domain.Entities
{
    public class UserInfo
    {
        public int UserEnrollNumber { get; set; }
        public string UserFullName { get; set; }
        public int UserIDD { get; set; }
        public string UserCalledName  { get; set; }

    }
}
