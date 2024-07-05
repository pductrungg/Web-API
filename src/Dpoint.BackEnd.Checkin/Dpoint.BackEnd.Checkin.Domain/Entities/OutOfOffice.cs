using Dpoint.BackEnd.Checkin.Common.Enums;

namespace Dpoint.BackEnd.Checkin.Domain.Entities
{
    public class OutOfOffice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double TotalHour { get; set; }
        public string Reason { get; set; }
        public string Note { get; set; }
        // public OutOfficeSta Status { get; set; }
        // public IEnumerable<OutOfOfficeDetail> OutOfficeDetails { get; set; }
    }
}
