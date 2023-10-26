using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class HopDong
    {
        [Key]
        [StringLength(10)]
        public string MaHD { get; set; }

        [Required]
        [StringLength(10)]
        public string MaPhongBan {  get; set; }

        [ForeignKey("MaPhongBan")]
        public PhongBan PhongBan { get; set; }

        [Required]
        [StringLength(10)]  
        public string MaNhanVien {  get; set; }

        [ForeignKey("MaNhanVien")]
        public NhanVien NhanVien { get; set; }

        [Required]
        [StringLength(10)]
        public string MaChucVu {  get; set; }

        [ForeignKey("MaChucVu")]
        public ChucVu ChucVu { get; set; }

        [Required]
        [StringLength(10)]
        public string MaQuyetDinh {  get; set; }

        [ForeignKey("MaQuyetDinh")]
        public QuyetDinh QuyetDinh { get; set; }
        


        [Required]
        public int IDHD {  get; set; }

        [ForeignKey("IDHD")]
        public LoaiHD LoaiHD { get; set; }
       

        [StringLength(10)]
        [Required]
        public string MaCheDo {  get; set; }

        [ForeignKey("MaCheDo")]
        public CheDoLamViec CheDoLamViec { get; set; }

        public float NgayKy { get; set; }


        public virtual ICollection<BaoHiemNhanVien> HopDongBaoHiemNhanVien { get; set; }
        public virtual ICollection<CTPhuCap> CTHopDongHopDong { get; set; }
    }
}
