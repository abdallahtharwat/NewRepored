using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    public partial class addcompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Build = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    apartmen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "Id", "Build", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress", "apartmen" },
                values: new object[] { 1, "D5", "cairo City", "Red Store", "6669990000", "12121", "IL", "123 Tech St", "33" });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "Id", "Build", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress", "apartmen" },
                values: new object[] { 2, "B1", "Vid City", "bubbly store", "7779990000", "66666", "IL", "999 Vid St", "53" });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "Id", "Build", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress", "apartmen" },
                values: new object[] { 3, "h4", "Lala land", "Weza store for women fashion", "1113335555", "99999", "NY", "999 Main St", "86" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companies");
        }
    }
}
