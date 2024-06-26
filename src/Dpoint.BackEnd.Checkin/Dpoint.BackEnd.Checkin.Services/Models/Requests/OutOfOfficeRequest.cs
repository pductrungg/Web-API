using Dpoint.BackEnd.Checkin.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dpoint.BackEnd.Checkin.Services.Models.Requests
{
    public class OutOfOfficeRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int DeptId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public double TotalHour { get; set; }
        [Required]
        public string Reason { get; set; }
        public string Note { get; set; }
    }
}
