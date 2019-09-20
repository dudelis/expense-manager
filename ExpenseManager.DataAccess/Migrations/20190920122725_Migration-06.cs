using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseManager.DataAccess.Migrations
{
    public partial class Migration06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DefaultCurrency",
                table: "UserSettings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthStartDay",
                table: "UserSettings",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultCurrency",
                table: "UserSettings");

            migrationBuilder.DropColumn(
                name: "MonthStartDay",
                table: "UserSettings");
        }
    }
}
