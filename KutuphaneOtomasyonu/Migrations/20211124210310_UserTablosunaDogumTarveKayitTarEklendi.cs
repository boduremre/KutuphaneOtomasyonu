using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneOtomasyonu.Migrations
{
    public partial class UserTablosunaDogumTarveKayitTarEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DogumTarihi",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "KayitTarihi",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DogumTarihi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KayitTarihi",
                table: "AspNetUsers");
        }
    }
}
