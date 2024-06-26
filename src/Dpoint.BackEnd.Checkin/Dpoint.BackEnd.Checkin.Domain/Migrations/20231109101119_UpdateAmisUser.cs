using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dpoint.BackEnd.Checkin.Domain.Migrations
{
    public partial class UpdateAmisUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AmisEmployee",
                columns: new[] { "Id", "AmisEmail", "AmisEmployeeCode", "IsAmisUser", "IsDeleted", "UserEmail" },
                values: new object[,]
                {
                    { "NV000060", "hieu.huynh@dgvdigital.com", "NV000060", false, false, "hieu.huynh@dgvdigital.com" },
                    { "NV000061", "truc.pham@dgvdigital.com", "NV000061", false, false, "truc.pham@dgvdigital.com" },
                    { "NV000062", "hoai.tran@dgvdigital.com", "NV000062", false, false, "hoai.tran@dgvdigital.com" },
                    { "TT000001", "tan.duong@dgvdigital.com", "TT000001", false, false, "tan.duong@dgvdigital.com" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: "NV000060");

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: "NV000061");

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: "NV000062");

            migrationBuilder.DeleteData(
                table: "AmisEmployee",
                keyColumn: "Id",
                keyValue: "TT000001");
        }
    }
}
