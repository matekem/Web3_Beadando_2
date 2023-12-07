using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web3_Beadando.Migrations
{
    public partial class NewSubject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AspNetUsers_TeacherIdId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_TeacherIdId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "TeacherIdId",
                table: "Subjects");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Subjects",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Subjects",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Classes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "SubjectId",
                table: "Assignments",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Subjects_SubjectId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_SubjectId",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Classes");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Subjects",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherIdId",
                table: "Subjects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Assignments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherIdId",
                table: "Subjects",
                column: "TeacherIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AspNetUsers_TeacherIdId",
                table: "Subjects",
                column: "TeacherIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
