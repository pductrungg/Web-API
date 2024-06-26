namespace Dpoint.BackEnd.Checkin.Services.Models.Dtos
{
    public class UserLoginDto  
    {
       public UserInfoDto Data { get; set; }
        public DtoToken Auth { get; set; }
    }
}
