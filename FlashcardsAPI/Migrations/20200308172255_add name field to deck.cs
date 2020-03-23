using Microsoft.EntityFrameworkCore.Migrations;

namespace FlashcardsAPI.Migrations
{
    public partial class addnamefieldtodeck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Decks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Decks");
        }
    }
}
