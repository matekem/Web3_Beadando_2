using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web3_Beadando.Migrations
{
    public partial class NewClass5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Classes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Classes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
