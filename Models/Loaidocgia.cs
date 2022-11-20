using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLTV_TKPM.Models
{
    [Table("Loaidocgia")]
    public class Loaidocgia
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Loại độc giả")]

        [Required]
        public string? TenLoaidocgia { get; set; } = null!;

        public bool? Daxoa { get; set; } = false;
    }
}
