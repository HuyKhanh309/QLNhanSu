using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class CTBangLuong
    {
        [Key]
        [Required]
        [StringLength(10)]    
        public string MaBangLuong { get; set; }

        [ForeignKey("MaBangLuong")]
        public virtual BangLuong BangLuong { get; set; }

        [Required]
        [StringLength(8)]
        public string MaKyLuong { get; set; }

        [ForeignKey("MaKyLuong")]
        public virtual KyLuong KyLuong { get; set; }     

        [Required]
        [StringLength(10)]
        public string MaNhanVien { get; set; }

        [ForeignKey("MaNhanVien")]
        public virtual NhanVien NhanVien { get; set; }


        [StringLength(10)]
        public string MaPhuCap { get; set; }

        [ForeignKey("MaPhuCap")]
        public virtual PhuCap PhuCap { get; set; }

        [StringLength(10)]
        public string MaPhieuUng {  get; set; }

        [ForeignKey("MaPhieuUng")]
        public virtual PhieuUngLuong PhieuUngLuong { get; set; }



        public float LuongPhuTroi { get; set; }
        public float LuongCoBan { get; set; }
        public float TongLuong { get; set; }


        
    }
}
