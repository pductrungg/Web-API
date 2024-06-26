using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dpoint.BackEnd.Checkin.Domain.Migrations
{
    public partial class CreateLeaveOfAbsenceDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveOfAbsenceDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveOfAbsenceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LeaveHours = table.Column<double>(type: "float", nullable: false),
                    LeaveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveOfAbsenceDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveOfAbsenceDetail_LeaveOfAbsence_LeaveOfAbsenceId",
                        column: x => x.LeaveOfAbsenceId,
                        principalTable: "LeaveOfAbsence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveOfAbsenceDetail_LeaveOfAbsenceId",
                table: "LeaveOfAbsenceDetail",
                column: "LeaveOfAbsenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveOfAbsenceDetail");
        }
    }
}
