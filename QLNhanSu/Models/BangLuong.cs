using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QLNhanSu.Models
{
    public class BangLuong
    {
        [Key]
        [StringLength(10)]
        public string MaBangLuong { get; set; }

        [Required]
        public DateTime NgayPhatLuong { get; set; }
   
        public virtual ICollection<CTBangLuong> CTBangLuongs { get; set; }
    }

}
