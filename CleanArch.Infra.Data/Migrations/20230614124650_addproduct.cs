using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    public partial class addproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Brand", "Code", "Color", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "H&M", 94, "White/Black striped", "\r\nShort-sleeved shirt in a linen and cotton weave with a resort collar, French front and open chest pocket. Yoke with darts at the back, and a straight-cut hem. Regular Fit – a classic fit with good room for movement and a gently tapered waist to create a comfortable, tailored silhouette. ", 240.0, "Regular Fit Resort shirt" },
                    { 2, "zara", 393, "white", "\r\nAnkle-length jeans in washed cotton denim with fake front pockets, real back pockets and straight legs. Wide jersey panel at the waist for best fit over the tummy. ", 625.0, "MAMA Straight Ankle Jeans" },
                    { 3, "Concret", 1630, "Khaki green", "\r\nSingle-breasted jacket in a stretch weave with narrow notch lapels with a decorative buttonhole, a chest pocket, flap front pockets and one inner pocket. Two buttons at the front, decorative buttons at the cuffs and a single back vent. Lined. Slim fit that tapers at the chest and waist which, combined with slightly narrower sleeves, creates a fitted silhouette. ", 2100.0, "Jacket Slim Fit" },
                    { 4, "zara", 10, "Beige", "\r\nT-shirt in soft cotton jersey with sleeves in contrasting colours. Relaxed fit with a round, rib-trimmed neckline, dropped shoulders, an open chest pocket and a straight-cut hem. ", 170.0, "Relaxed Fit Pocket-detail T-shirt" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
