using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class BaoHiemNhanVien
    {
        [Key]
        [StringLength(10)]
        public string MaBH { get; set; }

        [Required]
        public int ID { get; set; }


        [ForeignKey("ID")]
        public virtual BaoHiem BaoHiem { get; set; }

        [Required]
        [StringLength(10)]
        public string MaHD { get; set; }

        [ForeignKey("MaHD")]
        public virtual HopDong HopDong { get; set; }


        public float MucDong { get; set; }

        [Required]
        public DateTime NgayDong { get; set; }

    }

}
