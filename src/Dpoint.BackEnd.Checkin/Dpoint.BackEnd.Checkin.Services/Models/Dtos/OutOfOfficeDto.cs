﻿using Dpoint.BackEnd.Checkin.Common.Enums;
using Dpoint.BackEnd.Checkin.Domain.Entities;

namespace Dpoint.BackEnd.Checkin.Services.Models.Dtos
{
    public class OutOfOfficeDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double TotalHour { get; set; }
        public string Reason { get; set; }
        public string Note { get; set; }
        public string AmisEmployeeCode { get; set; }
        public string AmisEmail { get; set; }
        public string AmisDeptCode { get; set; }
        public string UserEmployeeCode { get; set; }
        public string UserEmail { get; set; }

    }
}
