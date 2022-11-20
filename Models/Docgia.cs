using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace QLTV_TKPM.Models
{
    [Table("Docgia")]
    public class Docgia
    {
        //public Docgia()
        //{
        //    Phieumuonsaches = new HashSet<Phieumuonsach>();
        //}

        [Key]
        public int Id { get; set; }

        [Display(Name = "Họ tên")]
        [Required]
        public string? Hoten { get; set; } = null!;

        [Display(Name = "Loại Độc giả")]
        public int LoaiDocGia { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required]
        public string? Diachi { get; set; } = null!;
        [Required]
        public string? Email { get; set; } = null!;
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Ngaysinh { get; set; } = DateTime.Today;

        [Display(Name = "Ngày lập thẻ")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Ngaylapthe { get; set; } = DateTime.Today;

        public bool? Daxoa { get; set; } = false;

        
        
    }
}
