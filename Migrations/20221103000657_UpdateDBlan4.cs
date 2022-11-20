using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTV_TKPM.Migrations
{
    public partial class UpdateDBlan4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Theloaisach",
                table: "Sach",
                newName: "TheloaisachId");

            migrationBuilder.RenameColumn(
                name: "MaDocGia",
                table: "Phieumuonsach",
                newName: "MaDocGiaId");

            migrationBuilder.RenameColumn(
                name: "Maphieumuonsach",
                table: "Phieumuonchitiet",
                newName: "MaphieumuonsachId");

            migrationBuilder.RenameColumn(
                name: "MaSach",
                table: "Phieumuonchitiet",
                newName: "MaSachId");

            migrationBuilder.RenameColumn(
                name: "LoaiDocGia",
                table: "Docgia",
                newName: "LoaiDocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sach_TheloaisachId",
                table: "Sach",
                column: "TheloaisachId");

            migrationBuilder.CreateIndex(
                name: "IX_Phieumuonsach_MaDocGiaId",
                table: "Phieumuonsach",
                column: "MaDocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Phieumuonchitiet_MaphieumuonsachId",
                table: "Phieumuonchitiet",
                column: "MaphieumuonsachId");

            migrationBuilder.CreateIndex(
                name: "IX_Phieumuonchitiet_MaSachId",
                table: "Phieumuonchitiet",
                column: "MaSachId");

            migrationBuilder.CreateIndex(
                name: "IX_Docgia_LoaiDocGiaId",
                table: "Docgia",
                column: "LoaiDocGiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Docgia_Loaidocgia_LoaiDocGiaId",
                table: "Docgia",
                column: "LoaiDocGiaId",
                principalTable: "Loaidocgia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phieumuonchitiet_Phieumuonsach_MaphieumuonsachId",
                table: "Phieumuonchitiet",
                column: "MaphieumuonsachId",
                principalTable: "Phieumuonsach",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phieumuonchitiet_Sach_MaSachId",
                table: "Phieumuonchitiet",
                column: "MaSachId",
                principalTable: "Sach",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Phieumuonsach_Docgia_MaDocGiaId",
                table: "Phieumuonsach",
                column: "MaDocGiaId",
                principalTable: "Docgia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sach_Theloaisach_TheloaisachId",
                table: "Sach",
                column: "TheloaisachId",
                principalTable: "Theloaisach",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docgia_Loaidocgia_LoaiDocGiaId",
                table: "Docgia");

            migrationBuilder.DropForeignKey(
                name: "FK_Phieumuonchitiet_Phieumuonsach_MaphieumuonsachId",
                table: "Phieumuonchitiet");

            migrationBuilder.DropForeignKey(
                name: "FK_Phieumuonchitiet_Sach_MaSachId",
                table: "Phieumuonchitiet");

            migrationBuilder.DropForeignKey(
                name: "FK_Phieumuonsach_Docgia_MaDocGiaId",
                table: "Phieumuonsach");

            migrationBuilder.DropForeignKey(
                name: "FK_Sach_Theloaisach_TheloaisachId",
                table: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_Sach_TheloaisachId",
                table: "Sach");

            migrationBuilder.DropIndex(
                name: "IX_Phieumuonsach_MaDocGiaId",
                table: "Phieumuonsach");

            migrationBuilder.DropIndex(
                name: "IX_Phieumuonchitiet_MaphieumuonsachId",
                table: "Phieumuonchitiet");

            migrationBuilder.DropIndex(
                name: "IX_Phieumuonchitiet_MaSachId",
                table: "Phieumuonchitiet");

            migrationBuilder.DropIndex(
                name: "IX_Docgia_LoaiDocGiaId",
                table: "Docgia");

            migrationBuilder.RenameColumn(
                name: "TheloaisachId",
                table: "Sach",
                newName: "Theloaisach");

            migrationBuilder.RenameColumn(
                name: "MaDocGiaId",
                table: "Phieumuonsach",
                newName: "MaDocGia");

            migrationBuilder.RenameColumn(
                name: "MaphieumuonsachId",
                table: "Phieumuonchitiet",
                newName: "Maphieumuonsach");

            migrationBuilder.RenameColumn(
                name: "MaSachId",
                table: "Phieumuonchitiet",
                newName: "MaSach");

            migrationBuilder.RenameColumn(
                name: "LoaiDocGiaId",
                table: "Docgia",
                newName: "LoaiDocGia");
        }
    }
}
