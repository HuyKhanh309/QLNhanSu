using System;
using System.Data.Entity;
using System.Linq;

namespace QLNhanSu.Models
{
    public class QLNhanSuDBContext : DbContext
    {
        // Your context has been configured to use a 'QLNhanSuDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QLNhanSu.Models.QLNhanSuDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'QLNhanSuDBContext' 
        // connection string in the application configuration file.
        public QLNhanSuDBContext()
            : base("name=QLNhanSuDBContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<BangLuong> BangLuongs { get; set; }
        public virtual DbSet<BaoHiem> BaoHiems { get; set; }
        public virtual DbSet<BaoHiemNhanVien> BaoHiemNhanViens { get; set; }
        public virtual DbSet<CTPhuCap> CTHopDongs { get; set; }
        public virtual DbSet<CheDoLamViec> CheDoLamViecs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<KyLuong> KyLuongs { get; set; }
        public virtual DbSet<LoaiHD> LoaiHDs { get; set; }
        public virtual DbSet<NghiPhep> NghiPheps { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhieuUngLuong> PhieuUngLuongs { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<PhuCap> PhuCaps { get; set; }
        public virtual DbSet<QuyetDinh> QuyetDinhs { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<CTBangCong> CTBangCongs { get; set; }
        public virtual DbSet<CTBangLuong> CTBangLuongs { get; set; }
        public virtual DbSet<LoaiCong> LoaiCongs { get; set; }
        public virtual DbSet<LoaiCa> LoaiCas { get; set; }
        public virtual DbSet<PhieuPhuTroi> PhieuPhuTrois { get; set; }
        public virtual DbSet<BangCong> BangCongs { get; set; }
    }
}

 /*   public class MyEntity
    {
       
       public string Name { get; set; }
    }
}*/