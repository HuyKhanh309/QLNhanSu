using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QLNhanSu.Models
{
    public class PhieuUngLuong
    {
        [Key]
        [StringLength(10)]
        public string MaPhieuUng { get; set; }

        [Required]
        [StringLength(10)]
        public string MaNhanVien {  get; set; }

        [ForeignKey("MaNhanVien")]
        public NhanVien NhanVien { get; set; }
      

        public virtual ICollection<CTBangLuong> CTBangLuongPhieuUngLuong { get; set; }
        public float MucUngLuong { get; set; }
        public DateTime NgayUng { get; set; }
    }
}
