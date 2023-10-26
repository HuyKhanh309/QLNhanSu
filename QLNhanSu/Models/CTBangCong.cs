using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class CTBangCong
    {
        [Key]
        [StringLength(10)]
        public string MaBangCong { get; set; }
        [ForeignKey("MaBangCong")]
        public virtual BangCong BangCong { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhanVien { get; set; }

        [ForeignKey("MaNhanVien")]
        public virtual NhanVien NhanVien { get; set; }

        [Required]
        [StringLength(10)]
        public string MaLoaiCa { get; set; }

        [ForeignKey("MaLoaiCa")]
        public virtual LoaiCa LoaiCa { get; set; }

        [Required]
        [StringLength(10)]
        public string MaLoaiCong { get; set; }

        [ForeignKey("MaLoaiCong")]
        public virtual LoaiCong LoaiCong { get; set; }

        [Required]
        [StringLength(10)]
        public string MaPhieuPT { get; set; }

        [ForeignKey("MaPhieuPT")]
        public virtual PhieuPhuTroi PhieuPhuTroi { get; set; }

        [Required]
        public DateTime Ngay { get; set; }

        public string SoGioLamCoBan { get; set; }
        public string SoGioLamPT { get; set; }
    }


}
