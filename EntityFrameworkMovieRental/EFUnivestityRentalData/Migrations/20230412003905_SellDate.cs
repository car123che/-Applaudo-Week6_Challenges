using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFUnivestityRentalData.Migrations
{
    public partial class SellDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellDate",
                table: "Sells",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellDate",
                table: "Sells");
        }
    }
}
