using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class PhongBan
    {
        [Key]
        [StringLength(10)]
        public string MaPhongBan { get; set; }

        [StringLength(250)]
        [Required]
        public string TenPhongBan { get; set; }

        [Required]
        public float PhuCapPB { get; set; }

        public virtual ICollection<HopDong> HopDongPhongBan { get; set; }
    }

}
