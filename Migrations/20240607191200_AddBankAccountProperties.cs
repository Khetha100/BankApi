using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApi.Migrations
{
    /// <inheritdoc />
    public partial class AddBankAccountProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "BankAccounts",
                newName: "AvailableBalance");

            migrationBuilder.RenameColumn(
                name: "IdNumber",
                table: "AccountHolders",
                newName: "IDNumber");

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "BankAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Withdrawals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BankAccountId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdrawals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Withdrawals");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BankAccounts");

            migrationBuilder.RenameColumn(
                name: "AvailableBalance",
                table: "BankAccounts",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "IDNumber",
                table: "AccountHolders",
                newName: "IdNumber");
        }
    }
}
