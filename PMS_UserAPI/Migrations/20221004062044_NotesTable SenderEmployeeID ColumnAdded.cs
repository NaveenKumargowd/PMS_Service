using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS_UserAPI.Migrations
{
    public partial class NotesTableSenderEmployeeIDColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "352df5d9-46a0-4345-8b72-4dda110b38a5");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5c801dbd-01fe-42bd-a58b-b42731764320");

            migrationBuilder.AddColumn<int>(
                name: "SenderEmployeeID",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c65e92f3-6e61-4d4a-8b21-29bfc575f1f8", "3a8f6814-7323-4e67-8e8d-76965df9548a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "857d9844-c3a6-4eea-b286-d335b0024160", "18f5971a-77d8-40f6-9742-1780a9cfa15e", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "857d9844-c3a6-4eea-b286-d335b0024160");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "c65e92f3-6e61-4d4a-8b21-29bfc575f1f8");

            migrationBuilder.DropColumn(
                name: "SenderEmployeeID",
                table: "Notes");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "352df5d9-46a0-4345-8b72-4dda110b38a5", "44c8d088-44af-4e99-830a-1842ad000e9a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c801dbd-01fe-42bd-a58b-b42731764320", "0d8902e2-3518-4d21-93c1-9e8812d60a7b", "Admin", "ADMIN" });
        }
    }
}
