using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class NhanVien
    {
        [Key]
        [StringLength(10)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(12)]
        public string CCCD { get; set; }

        [Required]
        public float LCB { get; set; }

        [Required]
        [StringLength(250)]
        public string HoTen { get; set; }

        [Required]
        public int GioiTinh { get; set; }

        [Required]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(10)]
        public string SDT { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public virtual ICollection<CTBangCong> CTBangCongNhanVien { get; set; }
        public virtual ICollection<CTBangLuong> CTBangLuongNhanVien { get; set; }
        public virtual ICollection<HopDong> HopDongNhanVien { get; set; }
        public virtual ICollection<NghiPhep> NghiPhepNhanVien { get; set; }
        public virtual ICollection<PhieuUngLuong> PhieuUngLuongNhanVien { get; set; }
    }
}
