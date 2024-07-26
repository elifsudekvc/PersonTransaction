using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonTransaction.DataAccessLayer.Migrations
{
    public partial class hangfireAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TCKimlik",
                table: "Persons",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_TCKimlik",
                table: "Persons",
                column: "TCKimlik",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_TCKimlik",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "TCKimlik",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }
    }
}
