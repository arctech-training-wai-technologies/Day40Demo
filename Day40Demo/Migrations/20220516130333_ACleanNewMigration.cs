using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day40Demo.Migrations
{
    public partial class ACleanNewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "master");

            migrationBuilder.EnsureSchema(
                name: "deductions");

            migrationBuilder.EnsureSchema(
                name: "accounts");

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequest",
                schema: "deductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeRefId = table.Column<int>(type: "int", nullable: false),
                    LeaveFrom = table.Column<DateTime>(type: "date", nullable: false),
                    LeaveTo = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequest_Employee_EmployeeRefId",
                        column: x => x.EmployeeRefId,
                        principalSchema: "master",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salary",
                schema: "accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeRefId = table.Column<int>(type: "int", nullable: false),
                    Ctc = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    VariableBonus = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salary_Employee_EmployeeRefId",
                        column: x => x.EmployeeRefId,
                        principalSchema: "master",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequest_EmployeeRefId",
                schema: "deductions",
                table: "LeaveRequest",
                column: "EmployeeRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Salary_EmployeeRefId",
                schema: "accounts",
                table: "Salary",
                column: "EmployeeRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequest",
                schema: "deductions");

            migrationBuilder.DropTable(
                name: "Salary",
                schema: "accounts");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "master");
        }
    }
}
