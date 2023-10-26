using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class ChucVu
    {
        [Key]
        [StringLength(10)]
        public string MaChucVu { get; set; }

        [StringLength(250)]
        [Required]
        public string TenChuCVu { get; set; }

        [Required]
        public float PhuCapCV { get; set; }
        public virtual ICollection<HopDong> HopDongChucVu { get; set; }
    }
}
