using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLTV_TKPM.Models
{
    [Table("Tuoidocgia")]
    public class Tuoidocgia
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tuổi tối thiểu")]
        [Required]
        public int TuoiMin { get; set; }

        [Display(Name = "Tuổi tối đa")]
        [Required]
        public int TuoiMax { get; set; }

        public bool? Daxoa { get; set; } = false;
    }
}
