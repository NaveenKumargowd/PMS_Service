using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS_UserAPI.Migrations
{
    public partial class NotesTableModified2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "a7200f4f-e12a-44f7-95e8-fec22d1f0ed1");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f9c9385e-70c4-4be3-bbbf-4adea33e4421");

            migrationBuilder.AlterColumn<int>(
                name: "ResponseNotesID",
                table: "Notes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "352df5d9-46a0-4345-8b72-4dda110b38a5", "44c8d088-44af-4e99-830a-1842ad000e9a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c801dbd-01fe-42bd-a58b-b42731764320", "0d8902e2-3518-4d21-93c1-9e8812d60a7b", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "352df5d9-46a0-4345-8b72-4dda110b38a5");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "5c801dbd-01fe-42bd-a58b-b42731764320");

            migrationBuilder.AlterColumn<int>(
                name: "ResponseNotesID",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9c9385e-70c4-4be3-bbbf-4adea33e4421", "3508ed3e-247a-4202-b0f9-b2036ac64241", "User", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7200f4f-e12a-44f7-95e8-fec22d1f0ed1", "203d0f8d-e151-47f0-85ab-c49c8f83ad67", "Admin", "ADMIN" });
        }
    }
}
