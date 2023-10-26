using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class KyLuong
    {
        [Key]
        [StringLength(8)]
        public string MaKyLuong { get; set; }

        [Required]
        public int Thang { get; set; }

        [Required]
        public int Nam { get; set; }

        public virtual ICollection<BangCong> BangCongs { get; set; }
        public virtual ICollection<CTBangLuong> CTBangLuongKyLuong { get; set; }
    }

}
