using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dpoint.BackEnd.Checkin.Domain.Migrations
{
    public partial class addFieldsToAmisEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
               name: "AmisEmployee");

            migrationBuilder.CreateTable(
              name: "AmisEmployee",
              columns: table => new
              {
                  Id = table.Column<string>(type: "nvarchar(50)", nullable: false),
                  AmisEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  AmisEmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                  IsAmisUser = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                  IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_AmisEmployee", x => x.Id);
              });


            migrationBuilder.InsertData(
                table: "AmisEmployee",
                columns: new[] { "Id", "AmisEmail", "AmisEmployeeCode", "IsAmisUser", "IsDeleted", "UserEmail" },
                values: new object[,]
                {
                    { "NV000000", "anh.chu@dgvdigital.com", "", true, true, "anh.chu@dgvdigital.com" },
                    { "NV000001", "tien.nguyen@dgvdigital.com", "NV000001", true, false, "tien.nguyen@dgvdigital.com" },
                    { "NV000002", "nhan@dgvdigital.com", "NV000002", true, false, "nhan@dgvdigital.com" },
                    { "NV000005", "hung@dgvdigital.com", "NV000005", true, false, "hung@dgvdigital.com" },
                    { "NV000007", "lien.huynh@dgvdigital.com", "NV000007", true, false, "lien.huynh@dgvdigital.com" },
                    { "NV000009", "huy.truong@dgvdigital.com", "NV000009", true, false, "huy.truong@dgvdigital.com" },
                    { "NV000010", "hao@dgvdigital.com", "NV000010", true, false, "hao@dgvdigital.com" },
                    { "NV000012", "hau@dgvdigital.com", "NV000012", true, false, "hau@dgvdigital.com" },
                    { "NV000013", "thao@dgvdigital.com", "NV000013", true, false, "thao@dgvdigital.com" },
                    { "NV000014", "quoc.le@dgvdigital.com", "NV000014", true, false, "quoc.le@dgvdigital.com" },
                    { "NV000016", "uyen.le@dgvdigital.com", "NV000016", true, false, "uyen.le@dgvdigital.com" },
                    { "NV000017", "oanh.nguyen@dgvdigital.com", "NV000017", true, false, "oanh.nguyen@dgvdigital.com" },
                    { "NV000018", "hai.tran@dgvdigital.com", "NV000018", true, false, "hai.tran@dgvdigital.com" },
                    { "NV000019", "quoc@dgvdigital.com", "NV000019", true, false, "quoc@dgvdigital.com" },
                    { "NV000020", "", "NV000020", false, false, "hoang.nguyen1@dgvdigital.com" },
                    { "NV000021", "duy.ngo@dgvdigital.com", "NV000021", true, false, "duy.ngo@dgvdigital.com" },
                    { "NV000022", "dung.nguyen@dgvdigital.com", "NV000022", true, false, "dung.nguyen@dgvdigital.com" },
                    { "NV000023", "thuy.nguyen@dgvdigital.com", "NV000023", true, false, "thuy.nguyen@dgvdigital.com" },
                    { "NV000024", "huyen.le@dgvdigital.com", "NV000024", true, false, "huyen.le@dgvdigital.com" },
                    { "NV000025", "doanh.nguyen@dgvdigital.com", "NV000025", true, false, "doanh.nguyen@dgvdigital.com" },
                    { "NV000026", "son.do@dgvdigital.com", "NV000026", true, false, "son.do@dgvdigital.com" },
                    { "NV000039", "", "NV000039", false, true, "nga.nguyen@dgvdigital.com" },
                    { "NV000040", "khoa.le@dgvdigital.com", "NV000040", true, false, "khoa.le@dgvdigital.com" },
                    { "NV000041", "", "NV000041", false, false, "manhdung.nguyen@dgvdigital.com" },
                    { "NV000042", "", "NV000042", false, false, "trong.truong@dgvdigital.com" },
                    { "NV000043", "", "NV000043", false, false, "dat.duong@dgvdigital.com" },
                    { "NV000044", "", "NV000044", false, false, "canh.lam@dgvdigital.com" },
                    { "NV000045", "", "NV000045", false, false, "hoang.nguyen@dgvdigital.com" },
                    { "NV000046", "", "NV000046", false, false, "tuan.pham@dgvdigital.com" },
                    { "NV000047", "", "NV000047", false, false, "loi.truong@dgvdigital.com" },
                    { "NV000048", "", "NV000048", false, false, "hoc.nguyen@dgvdigital.com" },
                    { "NV000049", "", "NV000049", false, false, "truc.bui@dgvdigital.com" },
                    { "NV000050", "", "NV000050", false, false, "duong.vu@dgvdigital.com" },
                    { "NV000051", "", "NV000051", false, false, "thu.pham@dgvdigital.com" },
                    { "NV000052", "", "NV000052", false, false, "phuonganh.do@dgvdigital.com" },
                    { "NV000053", "", "NV000053", false, true, "cong.vo@dgvdigital.com" },
                    { "NV000054", "", "NV000054", false, false, "quan.vo@dgvdigital.com" },
                    { "NV000055", "", "NV000055", false, false, "loan.le@dgvdigital.com" },
                    { "NV000056", "", "NV000056", false, false, "hoan.le@dgvdigital.com" },
                    { "NV000057", "", "NV000057", false, false, "hoa.duong@dgvdigital.com" },
                    { "NV000058", "", "NV000058", false, false, "phu.nguyen@dgvdigital.com" },
                    { "NV000059", "", "NV000059", false, false, "vanhoang.nguyen@dgvdigital.com" }
                });

            migrationBuilder.InsertData(
                table: "AmisEmployee",
                columns: new[] { "Id", "AmisEmail", "AmisEmployeeCode", "IsAmisUser", "IsDeleted", "UserEmail" },
                values: new object[,]
                {
                    { "NV999901", "product@dgvdigital.com", "NV999901", true, false, "product@dgvdigital.com" },
                    { "NV999902", "tech@dgvdigital.com", "NV999902", true, false, "tech@dgvdigital.com" },
                    { "NV999903a", "sales@dgvdigital.com", "NV999903a", true, false, "sales@dgvdigital.com" },
                    { "NV999903b", "sales_ho@dgvdigital.com", "NV999903b", true, false, "sales_ho@dgvdigital.com" },
                    { "NV999904", "marketing@dgvdigital.com", "NV999904", true, false, "marketing@dgvdigital.com" },
                    { "NV999905", "backoffice@dgvdigital.com", "NV999905", true, false, "backoffice@dgvdigital.com" },
                    { "NV999999", "isms@dgvdigital.com", "NV999999", true, false, "isms@dgvdigital.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "AmisEmployee");

            migrationBuilder.CreateTable(
               name: "AmisEmployee",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   AmisEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   AmisEmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                   IsDeleted = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_AmisEmployee", x => x.Id);
               });

            migrationBuilder.InsertData(
                table: "AmisEmployee",
                columns: new[] { "Id", "AmisEmail", "AmisEmployeeCode", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "sales_ho@dgvdigital.com", "NV999903b", 0 },
                    { 2, "sales@dgvdigital.com", "NV999903a", 0 },
                    { 3, "isms@dgvdigital.com", "NV999999", 0 },
                    { 4, "tech@dgvdigital.com", "NV999902", 0 },
                    { 5, "product@dgvdigital.com", "NV999901", 0 },
                    { 6, "duy.ngo@dgvdigital.com", "NV000021", 0 },
                    { 7, "backoffice@dgvdigital.com", "NV999905", 0 },
                    { 8, "marketing@dgvdigital.com", "NV999904", 0 },
                    { 9, "hau@dgvdigital.com", "NV000012", 0 },
                    { 10, "dung.nguyen@dgvdigital.com", "NV000022", 0 },
                    { 11, "doanh.nguyen@dgvdigital.com", "NV000025", 0 },
                    { 12, "thuy.nguyen@dgvdigital.com", "NV000023", 0 },
                    { 13, "quoc.le@dgvdigital.com", "NV000014", 0 },
                    { 14, "oanh.nguyen@dgvdigital.com", "NV000017", 0 },
                    { 15, "thao@dgvdigital.com", "NV000013", 0 },
                    { 16, "huyen.le@dgvdigital.com", "NV000024", 0 },
                    { 17, "uyen.le@dgvdigital.com", "NV000016", 0 },
                    { 18, "hoang.nguyen1@dgvdigital.com", "NV000020", 0 },
                    { 19, "son.do @dgvdigital.com", "NV000026", 0 },
                    { 20, "quoc@dgvdigital.com", "NV000019", 0 },
                    { 21, "hung@dgvdigital.com", "NV000005", 0 },
                    { 22, "huy.truong@dgvdigital.com", "NV000009", 0 },
                    { 23, "hao@dgvdigital.com", "NV000010", 0 },
                    { 24, "hai.tran@dgvdigital.com", "NV000018", 0 },
                    { 25, "lien.huynh@dgvdigital.com", "NV000007", 0 },
                    { 26, "khoa.le@dgvdigital.com", "NV000040", 0 },
                    { 27, "tien.nguyen@dgvdigital.com", "NV000001", 0 },
                    { 28, "nhan@dgvdigital.com", "NV000002", 0 }
                });
        }
    }
}
