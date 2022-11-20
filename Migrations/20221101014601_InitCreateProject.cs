using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTV_TKPM.Migrations
{
    public partial class InitCreateProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loaidocgia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaidocgia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loaidocgia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Soluongsachmuon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soluongsachmuontoida = table.Column<int>(type: "int", nullable: false),
                    Ngaymuontoida = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soluongsachmuon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Theloaisach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tentheloaisach = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theloaisach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Thoihanthe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sothang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thoihanthe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tuoidocgia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuoiMin = table.Column<int>(type: "int", nullable: false),
                    TuoiMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuoidocgia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Docgia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hoten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiDocGiaId = table.Column<int>(type: "int", nullable: false),
                    Diachi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ngaylapthe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Daxoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docgia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docgia_Loaidocgia_LoaiDocGiaId",
                        column: x => x.LoaiDocGiaId,
                        principalTable: "Loaidocgia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tensach = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheloaisachId = table.Column<int>(type: "int", nullable: false),
                    Tacgia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamXb = table.Column<int>(type: "int", nullable: false),
                    NhaXb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ngaynhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Daxoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sach_Theloaisach_TheloaisachId",
                        column: x => x.TheloaisachId,
                        principalTable: "Theloaisach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phieumuonchitiet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSachId = table.Column<int>(type: "int", nullable: false),
                    Daxoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phieumuonchitiet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phieumuonchitiet_Sach_MaSachId",
                        column: x => x.MaSachId,
                        principalTable: "Sach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phieumuonsach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDocGiaId = table.Column<int>(type: "int", nullable: false),
                    MaPhieuMuonChiTietId = table.Column<int>(type: "int", nullable: false),
                    NgayMuon = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Daxoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phieumuonsach", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phieumuonsach_Docgia_MaDocGiaId",
                        column: x => x.MaDocGiaId,
                        principalTable: "Docgia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phieumuonsach_Phieumuonchitiet_MaPhieuMuonChiTietId",
                        column: x => x.MaPhieuMuonChiTietId,
                        principalTable: "Phieumuonchitiet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docgia_LoaiDocGiaId",
                table: "Docgia",
                column: "LoaiDocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Phieumuonchitiet_MaSachId",
                table: "Phieumuonchitiet",
                column: "MaSachId");

            migrationBuilder.CreateIndex(
                name: "IX_Phieumuonsach_MaDocGiaId",
                table: "Phieumuonsach",
                column: "MaDocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Phieumuonsach_MaPhieuMuonChiTietId",
                table: "Phieumuonsach",
                column: "MaPhieuMuonChiTietId");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TheloaisachId",
                table: "Sach",
                column: "TheloaisachId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phieumuonsach");

            migrationBuilder.DropTable(
                name: "Soluongsachmuon");

            migrationBuilder.DropTable(
                name: "Thoihanthe");

            migrationBuilder.DropTable(
                name: "Tuoidocgia");

            migrationBuilder.DropTable(
                name: "Docgia");

            migrationBuilder.DropTable(
                name: "Phieumuonchitiet");

            migrationBuilder.DropTable(
                name: "Loaidocgia");

            migrationBuilder.DropTable(
                name: "Sach");

            migrationBuilder.DropTable(
                name: "Theloaisach");
        }
    }
}
