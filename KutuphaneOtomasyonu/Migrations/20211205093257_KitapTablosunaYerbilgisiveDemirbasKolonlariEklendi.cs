using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneOtomasyonu.Migrations
{
    public partial class KitapTablosunaYerbilgisiveDemirbasKolonlariEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DemirbasNo",
                table: "Kitap",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "YerBilgisi",
                table: "Kitap",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DemirbasNo",
                table: "Kitap");

            migrationBuilder.DropColumn(
                name: "YerBilgisi",
                table: "Kitap");
        }
    }
}
