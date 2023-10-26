using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class LoaiCa
    {
        [Key]
        [StringLength(10)]
        public string MaLoaiCa { get; set; }

        [Required]
        [StringLength(250)]
        public string TenLoaiCa { get; set; }

        [Required]
        [StringLength(250)]
        public string MoTa { get; set; }

        public virtual ICollection<CTBangCong> CTBangCongLoaiCa { get; set; }
    }
}
