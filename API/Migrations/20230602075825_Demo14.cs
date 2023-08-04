using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Demo14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerBasketId",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BasketItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CustomerBasketId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerBasketId",
                table: "BasketItems");
        }
    }
}
