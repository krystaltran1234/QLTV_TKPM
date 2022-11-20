using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace QLTV_TKPM.Models
{
    [Table("Sach")]
    public class Sach
    {
        //public Sach()
        //{
        //    Phieumuonchitiets = new HashSet<Phieumuonchitiet>();
        //}
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên sách")]
        [Required]
        public string? Tensach { get; set; } = null!;

        [Display(Name = "Thể loại")]
        [Required]
        public int Theloaisach { get; set; }

        [Display(Name = "Tác giả")]
        [Required]
        public string? Tacgia { get; set; } = null!;
        [Display(Name = "Năm xuất bản")]
        [Required]
        public int NamXb { get; set; }

        [Display(Name = "Nhà xuất bản")]
        [Required]
        public string? NhaXb { get; set; } = null!;

        [Display(Name = "Ngày nhập")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Ngaynhap { get; set; }

        [Display(Name = "Tình trạng")]
        public string Tinhtrang { get; set; } = "Chưa mượn";

        public bool? Daxoa { get; set; } = false;
        
    }
}
