using Dpoint.BackEnd.Checkin.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dpoint.BackEnd.Checkin.Domain.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<CheckInOut> CheckInOuts { get; set; }
        DbSet<UserInfo> UserInfos { get; set; }
        DbSet<RelationDept> RelationDepts { get; set; }
        DbSet<AmisEmployee> AmisEmployees { get; set; }
        DbSet<AmisDepartment> AmisDepartments { get; set; }
        DbSet<LeaveOfAbsence> LeaveOfAbsences { get; set; }
        DbSet<LeaveOfAbsenceDetail> LeaveOfAbsenceDetails { get; set; }
    }
}
