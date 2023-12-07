using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web3_Beadando.Migrations
{
    public partial class NewClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Subjects_SubjectId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_SubjectId",
                table: "Classes");

            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "Classes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Classes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "StartTime",
                table: "Classes",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Classes");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SubjectId",
                table: "Classes",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Subjects_SubjectId",
                table: "Classes",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
