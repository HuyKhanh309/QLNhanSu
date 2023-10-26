using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class BangCong
    {
        [Key]
        [StringLength(10)]
        public string MaBangCong { get; set; }

        [StringLength(8)]
        [Required]
        public string MaKyLuong { get; set; }

        [ForeignKey("MaKyLuong")]
        public virtual KyLuong KyLuong { get; set; }

        [Required]
        public DateTime NgayLapBang { get; set; }
        public virtual ICollection<CTBangCong> CTBangCongs { get; set; }
    }

}
