using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLTV_TKPM.Models
{
    [Table("Thoihanthe")]
    public class Thoihanthe
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Số tháng")]
        [Required]
        public int Sothang { get; set; }

        public bool? Daxoa { get; set; } = false;
    }
}
