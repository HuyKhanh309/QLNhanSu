using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class CTPhuCap
    {
        
        [Required]
        [StringLength(10)]
        public string MaPhuCap {  get; set; }

        [ForeignKey("MaPhuCap")]
        public virtual PhuCap PhuCap { get; set; }

        [Key]
        [Required]
        [StringLength(10)]
        public string MaHD {  get; set; }

        [ForeignKey("MaHD")]
        public virtual HopDong HopDong { get; set; }
      
        public DateTime ThoiHan {  get; set; }

    }
}
