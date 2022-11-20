using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace QLTV_TKPM.Models
{
    [Table("Phieumuonsach")]
    public class Phieumuonsach
    {
        //public Phieumuonsach()
        //{
        //    Phieumuonchitiets = new HashSet<Phieumuonchitiet>();
        //}
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên độc giả")]

        [ForeignKey("Docgia")]
        [Required]
        public int MaDocGia { get; set; }

        [Display(Name = "Ngày mượn")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime NgayMuon { get; set; }

        public bool? Daxoa { get; set; } = false;
        
    }
}
