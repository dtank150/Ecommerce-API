using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Data13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerBaskets",
                table: "CustomerBaskets");

            migrationBuilder.RenameTable(
                name: "CustomerBaskets",
                newName: "CustomerBasket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerBasket",
                table: "CustomerBasket",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerBasket",
                table: "CustomerBasket");

            migrationBuilder.RenameTable(
                name: "CustomerBasket",
                newName: "CustomerBaskets");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerBaskets",
                table: "CustomerBaskets",
                column: "Id");
        }
    }
}
