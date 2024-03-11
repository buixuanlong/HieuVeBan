using System.ComponentModel.DataAnnotations;

namespace HieuVeBan.Models.Entities.OldEntities
{
    public class TaiKhoan
    {
        [Key]
        public int Uid { get; set; }

        [MaxLength(50)]
        public string MaQuanLy { get; set; } = "";

        [MaxLength(50)]
        [Required]
        public string HoTen { get; set; } = "";

        [MaxLength(50)]
        [Required]
        public string Email { get; set; } = "";

        [MaxLength(500)]
        public string DonVi { get; set; } = "";

        [MaxLength(10)]
        public string Role { get; set; } = "";
    }
}
