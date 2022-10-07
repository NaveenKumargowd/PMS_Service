using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMS_UserAPI.Migrations
{
    public partial class NotesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "4f0bede8-9c6f-4fb3-962c-19a5191e074a");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9aafe278-afa8-4a87-8cf9-d2694468b822");

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipientEmployeeID = table.Column<int>(type: "int", nullable: false),
                    MessageDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResponseNotesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7ddf855d-9f83-43c0-85c1-35fcd5bfc301", "fd19ccca-8c6c-455e-ba17-d661e27f4957", "User", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c1fa637-ee1b-4fea-87cc-ea66a70fe95d", "8294de42-0be7-402f-8838-a120575a719e", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "6c1fa637-ee1b-4fea-87cc-ea66a70fe95d");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7ddf855d-9f83-43c0-85c1-35fcd5bfc301");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4f0bede8-9c6f-4fb3-962c-19a5191e074a", "07dd3044-34fb-4ce2-af00-40fabe282fbf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9aafe278-afa8-4a87-8cf9-d2694468b822", "503dfcb5-a49f-4ec9-8641-c0fdc8ffc292", "Admin", "ADMIN" });
        }
    }
}
