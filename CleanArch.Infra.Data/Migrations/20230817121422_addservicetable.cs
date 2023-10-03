using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    public partial class addservicetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "services",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "Our experienced advisors have a vast understanding of UAE banking regulations and procedures.", "Bank Account" });

            migrationBuilder.InsertData(
                table: "services",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 2, "Our knowledgeable team will navigate the complexities and requirements of various licenses and permits", "Licenses and Permits" });

            migrationBuilder.InsertData(
                table: "services",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 3, "Guide you through the essential steps for setting up a successful business.", "Free Consultancy" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "services");
        }
    }
}
