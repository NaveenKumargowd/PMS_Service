using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS_UserAPI.Migrations
{
    public partial class NotesTableUrgencyColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "857d9844-c3a6-4eea-b286-d335b0024160");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "c65e92f3-6e61-4d4a-8b21-29bfc575f1f8");

            migrationBuilder.AddColumn<bool>(
                name: "Urgency",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9a99955-7bc7-4f50-9238-b53121f0ac8a", "dd7ca269-ee24-4b42-97a0-070a4651fdcd", "User", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69330978-0dae-4301-b620-4075465b5e19", "360ff726-3dc2-4908-bec2-890558e1d413", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "69330978-0dae-4301-b620-4075465b5e19");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "d9a99955-7bc7-4f50-9238-b53121f0ac8a");

            migrationBuilder.DropColumn(
                name: "Urgency",
                table: "Notes");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c65e92f3-6e61-4d4a-8b21-29bfc575f1f8", "3a8f6814-7323-4e67-8e8d-76965df9548a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "857d9844-c3a6-4eea-b286-d335b0024160", "18f5971a-77d8-40f6-9742-1780a9cfa15e", "Admin", "ADMIN" });
        }
    }
}
