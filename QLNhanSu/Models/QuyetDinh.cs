using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class QuyetDinh
    {
        [Key]
        [Required]
        public string MaQuyetDinh { get; set; }

        [Required]
        [StringLength(250)]
        public string TenQuyetDinh { get; set; }

        [Required]
        public DateTime NgayQuyetDinh { get; set; }
        public virtual ICollection<HopDong> HopDongQuyetDinh { get; set; }
    }
}
