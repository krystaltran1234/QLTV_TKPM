using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace QLTV_TKPM.Models
{
    [Table("Phieumuonchitiet")]
    public class Phieumuonchitiet
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "sách")]
        [Required]
        [ForeignKey("Sach")]
        public int MaSach { get; set; }

        [Display(Name = "Phiếu mượn sách")]
        [ForeignKey("Phieumuonsach")]
        public int? Maphieumuonsach { get; set; }

        public bool? Daxoa { get; set; } = false;
    }
}
