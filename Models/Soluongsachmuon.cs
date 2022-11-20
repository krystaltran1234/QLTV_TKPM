using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLTV_TKPM.Models
{
    [Table("Soluongsachmuon")]
    public class Soluongsachmuon
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Số lượng sách mượn tối đa")]
        [Required]
        public int Soluongsachmuontoida { get; set; }

        [Display(Name = "Ngày mượn tối đa")]
        [Required]
        public int Ngaymuontoida { get; set; }

        public bool? Daxoa { get; set; } = false;

    }
}
