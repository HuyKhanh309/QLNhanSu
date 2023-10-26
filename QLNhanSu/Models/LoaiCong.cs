using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class LoaiCong
    {
        [Key]
        [StringLength(10)]
        public string MaLoaiCong { get; set; }

        [Required]
        [StringLength(250)]
        public string TenLoaiCong { get; set; }

        [Required]
        public float HeSoLuong { get; set; }

        public virtual ICollection<CTBangCong> CTBangCongLoaiCong { get; set; }
    }
}
