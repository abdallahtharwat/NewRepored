using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    public partial class updateservicetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Iconservice",
                table: "services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "services",
                keyColumn: "Id",
                keyValue: 1,
                column: "Iconservice",
                value: " <i class='bx bxs-check-shield'></i>");

            migrationBuilder.UpdateData(
                table: "services",
                keyColumn: "Id",
                keyValue: 2,
                column: "Iconservice",
                value: " <i class='bx bxs-check-shield'></i>");

            migrationBuilder.UpdateData(
                table: "services",
                keyColumn: "Id",
                keyValue: 3,
                column: "Iconservice",
                value: " <i class='bx bxs-check-shield'></i>");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Iconservice",
                table: "services");
        }
    }
}
