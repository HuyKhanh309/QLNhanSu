using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhanSu.Models
{
    public class TaiKhoan
    {
        [Key]
        [StringLength(10)]
        public string IdTaiKhoan { get; set; }

        [Required]
        [StringLength(250)]
        public string TaiKhoanName { get; set; }

        [Required]
        [StringLength(250)]
        public string MatKhau { get; set; }

        [Required]
        [StringLength(250)]
        public string TenNhanVien { get; set; }
    }
}
