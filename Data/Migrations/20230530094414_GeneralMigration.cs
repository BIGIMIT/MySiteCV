using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bortsevych.Data.Migrations
{
    /// <inheritdoc />
    public partial class GeneralMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Languages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HTMLPage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09wdbsbf-anrg-e7fd-4vds-3hreaf6ea2zf", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1wfw51eg-erah-trah-51sr-tj51ty4jd5t4", 0, "fc0409e2-430b-4eae-8aae-5a340675464e", "administrator@gmail.com", true, false, null, "ADMINISTRATOR@GMAIL.COM", "ADMINISTRATOR@GMAIL.COM", "AQAAAAIAAYagAAAAENODLrVJJ5Qr8Lb06aSHaAxkN5DnHSBMP+gr0GHdd/FFxjCvPpWfXo42xUfH+EPAhA==", null, false, "", false, "administrator@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "09wdbsbf-anrg-e7fd-4vds-3hreaf6ea2zf", "1wfw51eg-erah-trah-51sr-tj51ty4jd5t4" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Title",
                table: "Projects",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "09wdbsbf-anrg-e7fd-4vds-3hreaf6ea2zf", "1wfw51eg-erah-trah-51sr-tj51ty4jd5t4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09wdbsbf-anrg-e7fd-4vds-3hreaf6ea2zf");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1wfw51eg-erah-trah-51sr-tj51ty4jd5t4");
        }
    }
}
