using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanAPIUpdate.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<double>(type: "REAL", nullable: false),
                    InterestRate = table.Column<double>(type: "REAL", nullable: false),
                    LoanType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TermInMonths = table.Column<int>(type: "INTEGER", nullable: false),
                    Purpose = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    DocsVerified = table.Column<bool>(type: "INTEGER", nullable: false),
                    AppliedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EMIAmount = table.Column<double>(type: "REAL", nullable: false),
                    TotalPayable = table.Column<double>(type: "REAL", nullable: false),
                    TotalPaid = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "EMISchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoanId = table.Column<int>(type: "INTEGER", nullable: false),
                    MonthNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EMIAmount = table.Column<double>(type: "REAL", nullable: false),
                    PrincipalComponent = table.Column<double>(type: "REAL", nullable: false),
                    InterestComponent = table.Column<double>(type: "REAL", nullable: false),
                    RemainingBalance = table.Column<double>(type: "REAL", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMISchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EMISchedules_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMISchedules_LoanId",
                table: "EMISchedules",
                column: "LoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMISchedules");

            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
