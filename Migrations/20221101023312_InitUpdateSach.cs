using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTV_TKPM.Migrations
{
    public partial class InitUpdateSach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TinhTrang",
                table: "Sach");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TinhTrang",
                table: "Sach",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
