using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web3_Beadando.Migrations
{
    public partial class NewClassroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Classes_ClassId",
                table: "Classrooms");

            migrationBuilder.DropIndex(
                name: "IX_Classrooms_ClassId",
                table: "Classrooms");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Classrooms",
                newName: "isLab");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Classrooms",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Classrooms",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Classes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Classrooms");

            migrationBuilder.RenameColumn(
                name: "isLab",
                table: "Classrooms",
                newName: "ClassId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Classrooms",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Classes",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_ClassId",
                table: "Classrooms",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Classes_ClassId",
                table: "Classrooms",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
