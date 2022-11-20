using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLTV_TKPM.Models
{
    [Table("Theloaisach")]
    public class Theloaisach
    {
        //public Theloaisach()
        //{
        //    Saches = new HashSet<Sach>();
        //}

        [Key]
        public int Id { get; set; }

        [Display(Name = "Thể loại sách")]
        [Required]

        public string? Tentheloaisach { get; set; } = null!;

        public bool? Daxoa { get; set; } = false;
    }
}
