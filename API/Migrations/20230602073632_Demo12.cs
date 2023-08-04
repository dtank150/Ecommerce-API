using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Demo12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_customerBaskets",
                table: "customerBaskets");

            migrationBuilder.DeleteData(
                table: "customerBaskets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "customerBaskets",
                newName: "CustomerBaskets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerBaskets",
                table: "CustomerBaskets",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerBaskets",
                table: "CustomerBaskets");

            migrationBuilder.RenameTable(
                name: "CustomerBaskets",
                newName: "customerBaskets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customerBaskets",
                table: "customerBaskets",
                column: "Id");

            migrationBuilder.InsertData(
                table: "customerBaskets",
                columns: new[] { "Id", "Items" },
                values: new object[] { 1, 1 });
        }
    }
}
