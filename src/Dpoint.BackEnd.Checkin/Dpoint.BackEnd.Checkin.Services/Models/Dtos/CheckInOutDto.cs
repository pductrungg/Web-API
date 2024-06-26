
namespace Dpoint.BackEnd.Checkin.Services.Models.Dtos
{
    public class CheckInOutDto
    {
        public int UserEnrollNumber { get; set; }
        public DateTime TimeStr { get; set; }
        public DateTime TimeDate { get; set; }
        public string OriginType { get; set; }
        public string NewType { get; set; }
        public string Source { get; set; }
        public int MachineNo { get; set; }
        public int WorkCode { get; set; }
    }
}
