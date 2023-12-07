using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web3_Beadando.Migrations
{
    public partial class NewAssigment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_TeacherIdId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Subjects_SubjectId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_SubjectId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_TeacherIdId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "TeacherIdId",
                table: "Assignments");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Assignments",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Assignments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Assignments",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeacherIdId",
                table: "Assignments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SubjectId",
                table: "Assignments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherIdId",
                table: "Assignments",
                column: "TeacherIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_TeacherIdId",
                table: "Assignments",
                column: "TeacherIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Subjects_SubjectId",
                table: "Assignments",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
