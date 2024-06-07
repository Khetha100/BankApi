using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankApi.Migrations.Bank
{
    /// <inheritdoc />
    public partial class BankContexMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Withdrawals_BankAccounts_BankAccountId",
                table: "Withdrawals");

            migrationBuilder.DropIndex(
                name: "IX_Withdrawals_BankAccountId",
                table: "Withdrawals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Withdrawals_BankAccountId",
                table: "Withdrawals",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Withdrawals_BankAccounts_BankAccountId",
                table: "Withdrawals",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
