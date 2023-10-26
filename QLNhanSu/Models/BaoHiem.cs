using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class BaoHiem
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string TenBH { get; set; }

        public virtual ICollection<BaoHiemNhanVien> BaoHiemNhanVienBaoHiem { get; set; }
    }
}
