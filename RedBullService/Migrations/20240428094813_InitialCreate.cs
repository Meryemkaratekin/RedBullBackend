using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RedBullService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atleths",
                columns: table => new
                {
                    atlet_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kategori_id = table.Column<int>(type: "int", nullable: false),
                    adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resim_url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atleths", x => x.atlet_id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    urunId = table.Column<int>(type: "int", nullable: false),
                    kategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => new { x.urunId, x.kategoriId });
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    urunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    urunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    resimUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasketurunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.urunId);
                });

            migrationBuilder.CreateTable(
                name: "Basket",
                columns: table => new
                {
                    urunId = table.Column<int>(type: "int", nullable: false),
                    kullaniciId = table.Column<int>(type: "int", nullable: false),
                    tutar = table.Column<int>(type: "int", nullable: false),
                    BasketurunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basket", x => x.urunId);
                    table.ForeignKey(
                        name: "FK_Basket_Basket_BasketurunId",
                        column: x => x.BasketurunId,
                        principalTable: "Basket",
                        principalColumn: "urunId");
                    table.ForeignKey(
                        name: "FK_Basket_Products_urunId",
                        column: x => x.urunId,
                        principalTable: "Products",
                        principalColumn: "urunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    kullanici_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullanici_adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasketurunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.kullanici_id);
                    table.ForeignKey(
                        name: "FK_User_Basket_BasketurunId",
                        column: x => x.BasketurunId,
                        principalTable: "Basket",
                        principalColumn: "urunId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basket_BasketurunId",
                table: "Basket",
                column: "BasketurunId");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_kullaniciId",
                table: "Basket",
                column: "kullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BasketurunId",
                table: "Products",
                column: "BasketurunId");

            migrationBuilder.CreateIndex(
                name: "IX_User_BasketurunId",
                table: "User",
                column: "BasketurunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Products_urunId",
                table: "Categories",
                column: "urunId",
                principalTable: "Products",
                principalColumn: "urunId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Basket_BasketurunId",
                table: "Products",
                column: "BasketurunId",
                principalTable: "Basket",
                principalColumn: "urunId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_User_kullaniciId",
                table: "Basket",
                column: "kullaniciId",
                principalTable: "User",
                principalColumn: "kullanici_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Products_urunId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Basket_User_kullaniciId",
                table: "Basket");

            migrationBuilder.DropTable(
                name: "Atleths");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Basket");
        }
    }
}
