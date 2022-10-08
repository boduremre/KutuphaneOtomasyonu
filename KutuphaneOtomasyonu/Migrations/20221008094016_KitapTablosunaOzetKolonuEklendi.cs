using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneOtomasyonu.Migrations
{
    public partial class KitapTablosunaOzetKolonuEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ozet",
                table: "Kitap",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ozet",
                table: "Kitap");
        }
    }
}
