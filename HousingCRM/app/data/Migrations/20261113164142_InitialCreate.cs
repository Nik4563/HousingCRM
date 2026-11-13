using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousingCRM.app.data.Migrations;

/// <inheritdoc />
public partial class _20261113164142_InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "ManagementCompanies",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                MaxBotId = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ManagementCompanies", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Employees",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                FullName = table.Column<string>(type: "TEXT", nullable: false),
                Position = table.Column<string>(type: "TEXT", nullable: false),
                ManagementCompanyId = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Employees", x => x.Id);
                table.ForeignKey(
                    name: "FK_Employees_ManagementCompanies_ManagementCompanyId",
                    column: x => x.ManagementCompanyId,
                    principalTable: "ManagementCompanies",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Residents",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                FullName = table.Column<string>(type: "TEXT", nullable: false),
                Address = table.Column<string>(type: "TEXT", nullable: false),
                MaxUserId = table.Column<string>(type: "TEXT", nullable: false),
                ManagementCompanyId = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Residents", x => x.Id);
                table.ForeignKey(
                    name: "FK_Residents_ManagementCompanies_ManagementCompanyId",
                    column: x => x.ManagementCompanyId,
                    principalTable: "ManagementCompanies",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Requests",
            columns: table => new
            {
                Id = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Title = table.Column<string>(type: "TEXT", nullable: false),
                Description = table.Column<string>(type: "TEXT", nullable: false),
                Status = table.Column<string>(type: "TEXT", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                MaxMessageId = table.Column<string>(type: "TEXT", nullable: true),
                ResidentId = table.Column<int>(type: "INTEGER", nullable: false),
                ManagementCompanyId = table.Column<int>(type: "INTEGER", nullable: false),
                EmployeeId = table.Column<int>(type: "INTEGER", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Requests", x => x.Id);
                table.ForeignKey(
                    name: "FK_Requests_Employees_EmployeeId",
                    column: x => x.EmployeeId,
                    principalTable: "Employees",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_Requests_ManagementCompanies_ManagementCompanyId",
                    column: x => x.ManagementCompanyId,
                    principalTable: "ManagementCompanies",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Requests_Residents_ResidentId",
                    column: x => x.ResidentId,
                    principalTable: "Residents",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Employees_ManagementCompanyId",
            table: "Employees",
            column: "ManagementCompanyId");

        migrationBuilder.CreateIndex(
            name: "IX_Requests_EmployeeId",
            table: "Requests",
            column: "EmployeeId");

        migrationBuilder.CreateIndex(
            name: "IX_Requests_ManagementCompanyId",
            table: "Requests",
            column: "ManagementCompanyId");

        migrationBuilder.CreateIndex(
            name: "IX_Requests_ResidentId",
            table: "Requests",
            column: "ResidentId");

        migrationBuilder.CreateIndex(
            name: "IX_Residents_ManagementCompanyId",
            table: "Residents",
            column: "ManagementCompanyId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Requests");

        migrationBuilder.DropTable(
            name: "Employees");

        migrationBuilder.DropTable(
            name: "Residents");

        migrationBuilder.DropTable(
            name: "ManagementCompanies");
    }
}
