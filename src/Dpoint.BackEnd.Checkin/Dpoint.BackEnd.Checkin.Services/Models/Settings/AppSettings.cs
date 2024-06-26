namespace Dpoint.BackEnd.Checkin.Services.Models.Settings
{
    public class AppSettings
    {
        public GoogleSettings GoogleSettings { get; set; }
        public TokenSettings TokenSettings { get; set; }
        public AmisProcessSettings AmisProcessSettings { get; set; }

    }

    public class GoogleSettings
    {
        public string Googleapis { get; set; }
        public string Parameters { get; set; }
    }
    public class TokenSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
    }

    public class AmisProcessSettings
    {
        public string AmisProcessUrl { get; set; }
        public string AmisProcessEndPoint { get; set; }
        public string ContentType { get; set; }
        public string XClientid { get; set; }
        public string TenantID { get; set; }
    }
}
