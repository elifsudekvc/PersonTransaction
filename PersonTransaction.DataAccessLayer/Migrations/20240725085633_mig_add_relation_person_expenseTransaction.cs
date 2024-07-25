using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonTransaction.DataAccessLayer.Migrations
{
    public partial class mig_add_relation_person_expenseTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "ExpenseTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTransactions_PersonID",
                table: "ExpenseTransactions",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseTransactions_Persons_PersonID",
                table: "ExpenseTransactions",
                column: "PersonID",
                principalTable: "Persons",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseTransactions_Persons_PersonID",
                table: "ExpenseTransactions");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseTransactions_PersonID",
                table: "ExpenseTransactions");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "ExpenseTransactions");
        }
    }
}
