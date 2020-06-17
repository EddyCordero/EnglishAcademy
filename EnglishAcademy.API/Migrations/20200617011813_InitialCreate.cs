using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnglishAcademy.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsActive = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsActive = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: true),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsActive = table.Column<bool>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTimeOffset>(nullable: false),
                    CourseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "IsActive", "TeacherId", "Title", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2020, 6, 17, 1, 18, 12, 670, DateTimeKind.Utc).AddTicks(2560), null, "En este curso el estudiante aprendera a mantener conversaciones sencillas", true, null, "Engish 1", new DateTime(2020, 6, 17, 1, 18, 12, 670, DateTimeKind.Utc).AddTicks(2560) });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CourseId", "CreatedAt", "DateOfBirth", "DeletedAt", "FirstName", "IsActive", "LastName", "UpdatedAt" },
                values: new object[] { 1, null, new DateTime(2020, 6, 17, 1, 18, 12, 670, DateTimeKind.Utc).AddTicks(210), new DateTimeOffset(new DateTime(1995, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), null, "Maria", true, "Lorenzo", new DateTime(2020, 6, 17, 1, 18, 12, 670, DateTimeKind.Utc).AddTicks(210) });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "CreatedAt", "DateOfBirth", "DeletedAt", "FirstName", "IsActive", "LastName", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2020, 6, 17, 1, 18, 12, 642, DateTimeKind.Utc).AddTicks(4800), new DateTimeOffset(new DateTime(1995, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -4, 0, 0, 0)), null, "Juan", true, "Perez", new DateTime(2020, 6, 17, 1, 18, 12, 642, DateTimeKind.Utc).AddTicks(4790) });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
