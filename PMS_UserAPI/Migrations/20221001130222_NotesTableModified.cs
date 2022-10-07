using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS_UserAPI.Migrations
{
    public partial class NotesTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "6c1fa637-ee1b-4fea-87cc-ea66a70fe95d");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7ddf855d-9f83-43c0-85c1-35fcd5bfc301");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Notes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9c9385e-70c4-4be3-bbbf-4adea33e4421", "3508ed3e-247a-4202-b0f9-b2036ac64241", "User", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a7200f4f-e12a-44f7-95e8-fec22d1f0ed1", "203d0f8d-e151-47f0-85ab-c49c8f83ad67", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "a7200f4f-e12a-44f7-95e8-fec22d1f0ed1");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "f9c9385e-70c4-4be3-bbbf-4adea33e4421");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ddf855d-9f83-43c0-85c1-35fcd5bfc301", "fd19ccca-8c6c-455e-ba17-d661e27f4957", "User", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c1fa637-ee1b-4fea-87cc-ea66a70fe95d", "8294de42-0be7-402f-8838-a120575a719e", "Admin", "ADMIN" });
        }
    }
}
