using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web3_Beadando.Migrations
{
    public partial class NewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Subjects",
                newName: "TeacherIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                newName: "IX_Subjects_TeacherIdId");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Classrooms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TeacherIdId = table.Column<string>(type: "TEXT", nullable: true),
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Deadline = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_AspNetUsers_TeacherIdId",
                        column: x => x.TeacherIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assignments_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TeacherId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_ClassId",
                table: "Classrooms",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SubjectId",
                table: "Assignments",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherIdId",
                table: "Assignments",
                column: "TeacherIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classrooms_Classes_ClassId",
                table: "Classrooms",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_AspNetUsers_TeacherIdId",
                table: "Subjects",
                column: "TeacherIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classrooms_Classes_ClassId",
                table: "Classrooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_AspNetUsers_TeacherIdId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classrooms_ClassId",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "TeacherIdId",
                table: "Subjects",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Subjects_TeacherIdId",
                table: "Subjects",
                newName: "IX_Subjects_TeacherId");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Teachers_TeacherId",
                table: "Subjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
