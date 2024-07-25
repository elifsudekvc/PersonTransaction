using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonTransaction.DataAccessLayer.Migrations
{
    public partial class AddTCKimlikToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TCKimlik",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TCKimlik",
                table: "Persons");
        }
    }
}
