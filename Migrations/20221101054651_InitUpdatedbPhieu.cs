using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTV_TKPM.Migrations
{
    public partial class InitUpdatedbPhieu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaPhieuMuonChiTiet",
                table: "Phieumuonsach");

            migrationBuilder.AddColumn<int>(
                name: "Maphieumuonsach",
                table: "Phieumuonchitiet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Maphieumuonsach",
                table: "Phieumuonchitiet");

            migrationBuilder.AddColumn<int>(
                name: "MaPhieuMuonChiTiet",
                table: "Phieumuonsach",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
