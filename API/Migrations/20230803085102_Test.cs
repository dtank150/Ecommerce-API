using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomerBasket",
                columns: new[] { "Id", "ProductId" },
                values: new object[] { 1, 17 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerBasket",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
