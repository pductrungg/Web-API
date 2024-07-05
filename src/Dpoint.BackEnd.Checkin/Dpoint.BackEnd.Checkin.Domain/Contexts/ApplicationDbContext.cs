using Dpoint.BackEnd.Checkin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dpoint.BackEnd.Checkin.Domain.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CheckInOut> CheckInOuts { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<RelationDept> RelationDepts { get; set; }
        public DbSet<AmisEmployee> AmisEmployees { get; set; }
        public DbSet<AmisDepartment> AmisDepartments { get; set; }
        public DbSet<LeaveOfAbsence> LeaveOfAbsences { get; set; }
        public DbSet<LeaveOfAbsenceDetail> LeaveOfAbsenceDetails { get; set; }
        public DbSet<OutOfOffice> OutOfOffices { get; set; }
        // public DbSet<OutOfOfficeDetail> outOfOfficeDetails {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);

            builder.Entity<CheckInOut>().ToTable(nameof(CheckInOut), t => t.ExcludeFromMigrations()).HasNoKey();
            builder.Entity<UserInfo>().ToTable(nameof(UserInfo), t => t.ExcludeFromMigrations()).HasKey(x => x.UserEnrollNumber);
            builder.Entity<RelationDept>().ToTable(nameof(RelationDept), t => t.ExcludeFromMigrations()).HasKey(x => x.ID);

            builder.Entity<AmisEmployee>().ToTable(nameof(AmisEmployee)).HasKey(x => x.Id);
            builder.Entity<AmisEmployee>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<AmisEmployee>().HasData(
            new AmisEmployee { Id = "NV000059", AmisEmail = "", AmisEmployeeCode = "NV000059", UserEmail = "vanhoang.nguyen@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000020", AmisEmail = "", AmisEmployeeCode = "NV000020", UserEmail = "hoang.nguyen1@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000058", AmisEmail = "", AmisEmployeeCode = "NV000058", UserEmail = "phu.nguyen@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000057", AmisEmail = "", AmisEmployeeCode = "NV000057", UserEmail = "hoa.duong@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000056", AmisEmail = "", AmisEmployeeCode = "NV000056", UserEmail = "hoan.le@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000053", AmisEmail = "", AmisEmployeeCode = "NV000053", UserEmail = "cong.vo@dgvdigital.com", IsAmisUser = false, IsDeleted = true },
            new AmisEmployee { Id = "NV000055", AmisEmail = "", AmisEmployeeCode = "NV000055", UserEmail = "loan.le@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000054", AmisEmail = "", AmisEmployeeCode = "NV000054", UserEmail = "quan.vo@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000052", AmisEmail = "", AmisEmployeeCode = "NV000052", UserEmail = "phuonganh.do@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV999903b", AmisEmail = "sales_ho@dgvdigital.com", AmisEmployeeCode = "NV999903b", UserEmail = "sales_ho@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000016", AmisEmail = "uyen.le@dgvdigital.com", AmisEmployeeCode = "NV000016", UserEmail = "uyen.le@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000025", AmisEmail = "doanh.nguyen@dgvdigital.com", AmisEmployeeCode = "NV000025", UserEmail = "doanh.nguyen@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000051", AmisEmail = "", AmisEmployeeCode = "NV000051", UserEmail = "thu.pham@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000007", AmisEmail = "lien.huynh@dgvdigital.com", AmisEmployeeCode = "NV000007", UserEmail = "lien.huynh@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000050", AmisEmail = "", AmisEmployeeCode = "NV000050", UserEmail = "duong.vu@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000049", AmisEmail = "", AmisEmployeeCode = "NV000049", UserEmail = "truc.bui@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000048", AmisEmail = "", AmisEmployeeCode = "NV000048", UserEmail = "hoc.nguyen@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000047", AmisEmail = "", AmisEmployeeCode = "NV000047", UserEmail = "loi.truong@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000046", AmisEmail = "", AmisEmployeeCode = "NV000046", UserEmail = "tuan.pham@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000045", AmisEmail = "", AmisEmployeeCode = "NV000045", UserEmail = "hoang.nguyen@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000043", AmisEmail = "", AmisEmployeeCode = "NV000043", UserEmail = "dat.duong@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000042", AmisEmail = "", AmisEmployeeCode = "NV000042", UserEmail = "trong.truong@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000044", AmisEmail = "", AmisEmployeeCode = "NV000044", UserEmail = "canh.lam@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000041", AmisEmail = "", AmisEmployeeCode = "NV000041", UserEmail = "manhdung.nguyen@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000009", AmisEmail = "huy.truong@dgvdigital.com", AmisEmployeeCode = "NV000009", UserEmail = "huy.truong@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000039", AmisEmail = "", AmisEmployeeCode = "NV000039", UserEmail = "nga.nguyen@dgvdigital.com", IsAmisUser = false, IsDeleted = true },
            new AmisEmployee { Id = "NV999903a", AmisEmail = "sales@dgvdigital.com", AmisEmployeeCode = "NV999903a", UserEmail = "sales@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000000", AmisEmail = "anh.chu@dgvdigital.com", AmisEmployeeCode = "", UserEmail = "anh.chu@dgvdigital.com", IsAmisUser = true, IsDeleted = true },
            new AmisEmployee { Id = "NV999999", AmisEmail = "isms@dgvdigital.com", AmisEmployeeCode = "NV999999", UserEmail = "isms@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV999902", AmisEmail = "tech@dgvdigital.com", AmisEmployeeCode = "NV999902", UserEmail = "tech@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV999901", AmisEmail = "product@dgvdigital.com", AmisEmployeeCode = "NV999901", UserEmail = "product@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000021", AmisEmail = "duy.ngo@dgvdigital.com", AmisEmployeeCode = "NV000021", UserEmail = "duy.ngo@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV999905", AmisEmail = "backoffice@dgvdigital.com", AmisEmployeeCode = "NV999905", UserEmail = "backoffice@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV999904", AmisEmail = "marketing@dgvdigital.com", AmisEmployeeCode = "NV999904", UserEmail = "marketing@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000012", AmisEmail = "hau@dgvdigital.com", AmisEmployeeCode = "NV000012", UserEmail = "hau@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000022", AmisEmail = "dung.nguyen@dgvdigital.com", AmisEmployeeCode = "NV000022", UserEmail = "dung.nguyen@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000023", AmisEmail = "thuy.nguyen@dgvdigital.com", AmisEmployeeCode = "NV000023", UserEmail = "thuy.nguyen@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000014", AmisEmail = "quoc.le@dgvdigital.com", AmisEmployeeCode = "NV000014", UserEmail = "quoc.le@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000017", AmisEmail = "oanh.nguyen@dgvdigital.com", AmisEmployeeCode = "NV000017", UserEmail = "oanh.nguyen@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000013", AmisEmail = "thao@dgvdigital.com", AmisEmployeeCode = "NV000013", UserEmail = "thao@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000024", AmisEmail = "huyen.le@dgvdigital.com", AmisEmployeeCode = "NV000024", UserEmail = "huyen.le@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000026", AmisEmail = "son.do@dgvdigital.com", AmisEmployeeCode = "NV000026", UserEmail = "son.do@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000019", AmisEmail = "quoc@dgvdigital.com", AmisEmployeeCode = "NV000019", UserEmail = "quoc@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000005", AmisEmail = "hung@dgvdigital.com", AmisEmployeeCode = "NV000005", UserEmail = "hung@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000010", AmisEmail = "hao@dgvdigital.com", AmisEmployeeCode = "NV000010", UserEmail = "hao@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000018", AmisEmail = "hai.tran@dgvdigital.com", AmisEmployeeCode = "NV000018", UserEmail = "hai.tran@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000040", AmisEmail = "khoa.le@dgvdigital.com", AmisEmployeeCode = "NV000040", UserEmail = "khoa.le@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000001", AmisEmail = "tien.nguyen@dgvdigital.com", AmisEmployeeCode = "NV000001", UserEmail = "tien.nguyen@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000002", AmisEmail = "nhan@dgvdigital.com", AmisEmployeeCode = "NV000002", UserEmail = "nhan@dgvdigital.com", IsAmisUser = true, IsDeleted = false },
            new AmisEmployee { Id = "NV000061", AmisEmail = "truc.pham@dgvdigital.com", AmisEmployeeCode = "NV000061", UserEmail = "truc.pham@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000062", AmisEmail = "hoai.tran@dgvdigital.com", AmisEmployeeCode = "NV000062", UserEmail = "hoai.tran@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "TT000001", AmisEmail = "tan.duong@dgvdigital.com", AmisEmployeeCode = "TT000001", UserEmail = "tan.duong@dgvdigital.com", IsAmisUser = false, IsDeleted = false },
            new AmisEmployee { Id = "NV000060", AmisEmail = "hieu.huynh@dgvdigital.com", AmisEmployeeCode = "NV000060", UserEmail = "hieu.huynh@dgvdigital.com", IsAmisUser = false, IsDeleted = false });

            builder.Entity<AmisDepartment>().ToTable(nameof(AmisDepartment)).HasKey(x => x.Id);
            builder.Entity<AmisDepartment>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<AmisDepartment>().HasData(
                new AmisDepartment { Id = 1, InternalDeptId = 2, AmisDeptCode = "DV03", AmisDeptEmail = "backoffice@dgvdigital.com", AmisDeptEmployeeCode = "NV999905" },
                new AmisDepartment { Id = 2, InternalDeptId = 4, AmisDeptCode = "DV01", AmisDeptEmail = "tech@dgvdigital.com", AmisDeptEmployeeCode = "NV999902" },
                new AmisDepartment { Id = 3, InternalDeptId = 6, AmisDeptCode = "DV07", AmisDeptEmail = "backoffice@dgvdigital.com", AmisDeptEmployeeCode = "NV999905" },
                new AmisDepartment { Id = 4, InternalDeptId = 7, AmisDeptCode = "DV05", AmisDeptEmail = "product@dgvdigital.com", AmisDeptEmployeeCode = "NV999901" },
                new AmisDepartment { Id = 5, InternalDeptId = 8, AmisDeptCode = "DV04", AmisDeptEmail = "sales@dgvdigital.com", AmisDeptEmployeeCode = "NV999903a" },
                new AmisDepartment { Id = 6, InternalDeptId = 9, AmisDeptCode = "DV02", AmisDeptEmail = "marketing@dgvdigital.com", AmisDeptEmployeeCode = "NV999904" },
                new AmisDepartment { Id = 7, InternalDeptId = 10, AmisDeptCode = "DV06", AmisDeptEmail = "backoffice@dgvdigital.com", AmisDeptEmployeeCode = "NV999905" },
                new AmisDepartment { Id = 8, InternalDeptId = 1, AmisDeptCode = "DV08", AmisDeptEmail = "backoffice@dgvdigital.com", AmisDeptEmployeeCode = "NV999905" });

            builder.Entity<LeaveOfAbsence>().ToTable(nameof(LeaveOfAbsence)).HasKey(x => x.Id);
            builder.Entity<LeaveOfAbsence>().Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Entity<LeaveOfAbsenceDetail>().ToTable(nameof(LeaveOfAbsenceDetail)).HasKey(x => x.Id);
            builder.Entity<LeaveOfAbsenceDetail>().Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Entity<LeaveOfAbsence>().HasMany(p => p.LeaveOfAbsenceDetails).WithOne(p => p.LeaveOfAbsence).HasForeignKey(p => p.LeaveOfAbsenceId);

            builder.Entity<OutOfOffice>().ToTable(nameof(OutOfOffice)).HasKey(x => x.Id);
            builder.Entity<OutOfOffice>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}


