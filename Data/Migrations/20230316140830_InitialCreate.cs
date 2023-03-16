using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bortsevych.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "09wdbsbf-anrg-e7fd-4vds-3hreaf6ea2zf", null, "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1wfw51eg-erah-trah-51sr-tj51ty4jd5t4", 0, "e7fbbb04-10ef-40b6-a39d-100806e33527", "administrator@gmail.com", true, false, null, "ADMINISTRATOR@GMAIL.COM", "ADMINISTRATOR@GMAIL.COM", "AQAAAAIAAYagAAAAECZYT6YyjuowKV23f/xExKtHSXAju3CAftlIYPX6Ub+UsdALryUdn9DZIqEdko2chA==", null, false, "", false, "administrator@gmail.com" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ID", "CreateAt", "Description", "HTMLPage", "Languages", "Title", "UpdateAt" },
                values: new object[] { "54b9f288-9992-4f27-ab2a-a350f25732f1", new DateTime(2023, 3, 16, 16, 8, 30, 320, DateTimeKind.Local).AddTicks(9966), "Defolt Descriptiondaw", "<h1>Defolt Projectdaw</h1>", "Defolt Languagesdaw", "Defolt Projectdaw", new DateTime(2023, 3, 16, 16, 8, 30, 320, DateTimeKind.Local).AddTicks(9969) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "09wdbsbf-anrg-e7fd-4vds-3hreaf6ea2zf", "1wfw51eg-erah-trah-51sr-tj51ty4jd5t4" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Title",
                table: "Projects",
                column: "Title");
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
