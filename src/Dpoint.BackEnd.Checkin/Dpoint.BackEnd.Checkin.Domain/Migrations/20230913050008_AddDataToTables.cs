using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dpoint.BackEnd.Checkin.Domain.Migrations
{
    public partial class AddDataToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequest");

            migrationBuilder.CreateTable(
                name: "LeaveOfAbsence",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LeaveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalLeaveHour = table.Column<double>(type: "float", nullable: false),
                    LeaveReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveOfAbsence", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AmisDepartment",
                columns: new[] { "Id", "AmisDeptCode", "AmisDeptEmail", "AmisDeptEmployeeCode", "InternalDeptId" },
                values: new object[,]
                {
                    { 1, "DV03", "backoffice@dgvdigital.com", "NV999905", 2 },
                    { 2, "DV01", "tech@dgvdigital.com", "NV999902", 4 },
                    { 3, "DV07", "backoffice@dgvdigital.com", "NV999905", 6 },
                    { 4, "DV05", "product@dgvdigital.com", "NV999901", 7 },
                    { 5, "DV04", "sales@dgvdigital.com", "NV999903a", 8 },
                    { 6, "DV02", "marketing@dgvdigital.com", "NV999904", 9 },
                    { 7, "DV06", "backoffice@dgvdigital.com", "NV999905", 10 },
                    { 8, "DV08", "backoffice@dgvdigital.com", "NV999905", 1 }
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveOfAbsence");

            migrationBuilder.DeleteData(
                table: "AmisDepartment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AmisDepartment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AmisDepartment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AmisDepartment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AmisDepartment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AmisDepartment",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AmisDepartment",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AmisDepartment",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.CreateTable(
                name: "LeaveRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalLeaveHour = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequest", x => x.Id);
                });
        }
    }
}
