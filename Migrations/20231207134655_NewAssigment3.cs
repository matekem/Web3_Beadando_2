using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web3_Beadando.Migrations
{
    public partial class NewAssigment3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Assignments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Assignments");
        }
    }
}
