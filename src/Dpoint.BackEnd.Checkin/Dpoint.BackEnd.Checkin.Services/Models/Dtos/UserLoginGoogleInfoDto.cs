
using Newtonsoft.Json;

namespace Dpoint.BackEnd.Checkin.Services.Models.Dtos
{
    public class UserLoginGoogleInfoDto 
    {
 
        public string Email { get; set; }

        [JsonProperty("family_name")]
        public string FamilyName{ get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }
        public string Hd { get; set; }
        public string Id { get; set; }
        public string Locale { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }

       [JsonProperty("verified_email")] 
        public bool VerifiedEmail { get; set; }  

    }
}
