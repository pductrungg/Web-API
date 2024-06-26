namespace Dpoint.BackEnd.Checkin.Domain.Entities
{
    public class AmisEmployee
    {
        public string Id { get; set; }
        public string AmisEmail { get; set; }
        public string UserEmail { get; set; }
        public string AmisEmployeeCode { get; set; }
        public bool IsAmisUser { get; set; }
        public bool IsDeleted { get; set; }

    }
}
