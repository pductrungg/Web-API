using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dpoint.BackEnd.Checkin.Domain.Migrations
{
    public partial class initCreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmisDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternalDeptId = table.Column<int>(type: "int", nullable: false),
                    AmisDeptCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmisDeptEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmisDeptEmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmisDepartment", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "LeaveRequest",
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
                    table.PrimaryKey("PK_LeaveRequest", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmisDepartment");

            migrationBuilder.DropTable(
                name: "AmisEmployee");

            migrationBuilder.DropTable(
                name: "LeaveRequest");
        }
    }
}
