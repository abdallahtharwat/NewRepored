using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    public partial class abdo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Brand", "CategoryId", "Code", "Color", "Description", "Price", "Title" },
                values: new object[] { 5, "polo", 2, 120, "red", "\r\nT-shirt in soft cotton jersey with sleeves in contrasting colours. Relaxed fit with a round, rib-trimmed neckline, dropped shoulders, an open chest pocket and a straight-cut hem. ", 1270.0, "T-shirt" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Brand", "CategoryId", "Code", "Color", "Description", "Price", "Title" },
                values: new object[] { 6, "zara", 3, 410, "white", "\r\nT-shirt in soft cotton jersey with sleeves in contrasting colours. Relaxed fit with a round, rib-trimmed neckline, dropped shoulders, an open chest pocket and a straight-cut hem. ", 470.0, "jeans" });
        }
    }
}
