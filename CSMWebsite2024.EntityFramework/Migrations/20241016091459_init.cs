using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CSMWebsite2024.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Points = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CreatedAt", "Description", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("d2c47548-0c60-4260-b6c4-121356074545"), new Guid("3c5fca94-7ed4-45c4-b432-f68554ff0b41"), new DateTime(2024, 10, 16, 17, 14, 59, 223, DateTimeKind.Local).AddTicks(9368), "IS Department welcomes 24 new students", "IS COURSE HAS NEW STUDENTS", new DateTime(2024, 10, 16, 17, 14, 59, 223, DateTimeKind.Local).AddTicks(9369) },
                    { new Guid("d846d060-efda-40da-874b-d55432ea913e"), new Guid("42a5979e-665c-4c8a-86d0-3d0489cda67c"), new DateTime(2024, 10, 16, 17, 14, 59, 223, DateTimeKind.Local).AddTicks(9370), "See Academic Calendar for details", "SPORTSFEST IS APPROACHING", new DateTime(2024, 10, 16, 17, 14, 59, 223, DateTimeKind.Local).AddTicks(9371) },
                    { new Guid("e042b0f1-3d7a-4b34-bf26-fc0bfe2bebbd"), new Guid("49e86f3d-7c33-460f-80dc-47af528fdaf6"), new DateTime(2024, 10, 16, 17, 14, 59, 223, DateTimeKind.Local).AddTicks(9356), "Admins open the school year", "SCHOOL YEAR IS OPEN", new DateTime(2024, 10, 16, 17, 14, 59, 223, DateTimeKind.Local).AddTicks(9366) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName", "Points" },
                values: new object[,]
                {
                    { new Guid("3c5fca94-7ed4-45c4-b432-f68554ff0b41"), "jbeleren@mailinator.com", "Jace", "Beleren", 3 },
                    { new Guid("42a5979e-665c-4c8a-86d0-3d0489cda67c"), "lvess@mailinator.com", "Liliana", "Vess", 3 },
                    { new Guid("49e86f3d-7c33-460f-80dc-47af528fdaf6"), "etirel@mailinator.com", "Elspeth", "Tirel", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
