using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BasketItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerBasketId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BasketItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerBasketId",
                value: 0);
        }
    }
}
