using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    public partial class addtypekey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "typeId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                column: "typeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "typeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                column: "typeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                column: "typeId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_products_typeId",
                table: "products",
                column: "typeId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_types_typeId",
                table: "products",
                column: "typeId",
                principalTable: "types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_types_typeId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_typeId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "typeId",
                table: "products");
        }
    }
}
