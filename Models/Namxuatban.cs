using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLTV_TKPM.Models
{
    [Table("Namxuatban")]
    public class Namxuatban
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Năm xuất bản")]
        [Required]
        public int Namxuatbang { get; set; }

        public bool? Daxoa { get; set; } = false;
    }
}
