using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneOtomasyonu.Migrations
{
    public partial class KitapTablosunaKayitveGuncellemeTarihleriEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "GuncellemeTarihi",
                table: "Kitap",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "KayitTarihi",
                table: "Kitap",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuncellemeTarihi",
                table: "Kitap");

            migrationBuilder.DropColumn(
                name: "KayitTarihi",
                table: "Kitap");
        }
    }
}
