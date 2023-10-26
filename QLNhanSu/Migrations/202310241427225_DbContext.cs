namespace QLNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BangCongs",
                c => new
                    {
                        MaBangCong = c.String(nullable: false, maxLength: 10),
                        MaKyLuong = c.String(nullable: false, maxLength: 8),
                        NgayLapBang = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaBangCong)
                .ForeignKey("dbo.KyLuongs", t => t.MaKyLuong, cascadeDelete: true)
                .Index(t => t.MaKyLuong);
            
            CreateTable(
                "dbo.CTBangCongs",
                c => new
                    {
                        MaBangCong = c.String(nullable: false, maxLength: 10),
                        MaNhanVien = c.String(nullable: false, maxLength: 10),
                        MaLoaiCa = c.String(nullable: false, maxLength: 10),
                        MaLoaiCong = c.String(nullable: false, maxLength: 10),
                        MaPhieuPT = c.String(nullable: false, maxLength: 10),
                        Ngay = c.DateTime(nullable: false),
                        SoGioLamCoBan = c.String(),
                        SoGioLamPT = c.String(),
                    })
                .PrimaryKey(t => t.MaBangCong)
                .ForeignKey("dbo.BangCongs", t => t.MaBangCong)
                .ForeignKey("dbo.LoaiCas", t => t.MaLoaiCa, cascadeDelete: true)
                .ForeignKey("dbo.LoaiCongs", t => t.MaLoaiCong, cascadeDelete: true)
                .ForeignKey("dbo.NhanViens", t => t.MaNhanVien, cascadeDelete: true)
                .ForeignKey("dbo.PhieuPhuTrois", t => t.MaPhieuPT, cascadeDelete: true)
                .Index(t => t.MaBangCong)
                .Index(t => t.MaNhanVien)
                .Index(t => t.MaLoaiCa)
                .Index(t => t.MaLoaiCong)
                .Index(t => t.MaPhieuPT);
            
            CreateTable(
                "dbo.LoaiCas",
                c => new
                    {
                        MaLoaiCa = c.String(nullable: false, maxLength: 10),
                        TenLoaiCa = c.String(nullable: false, maxLength: 250),
                        MoTa = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.MaLoaiCa);
            
            CreateTable(
                "dbo.LoaiCongs",
                c => new
                    {
                        MaLoaiCong = c.String(nullable: false, maxLength: 10),
                        TenLoaiCong = c.String(nullable: false, maxLength: 250),
                        HeSoLuong = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaLoaiCong);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        MaNhanVien = c.String(nullable: false, maxLength: 10),
                        CCCD = c.String(nullable: false, maxLength: 12),
                        LCB = c.Single(nullable: false),
                        HoTen = c.String(nullable: false, maxLength: 250),
                        GioiTinh = c.Int(nullable: false),
                        NgaySinh = c.DateTime(nullable: false),
                        SDT = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.CTBangLuongs",
                c => new
                    {
                        MaBangLuong = c.String(nullable: false, maxLength: 10),
                        MaKyLuong = c.String(nullable: false, maxLength: 8),
                        MaNhanVien = c.String(nullable: false, maxLength: 10),
                        MaPhuCap = c.String(maxLength: 10),
                        MaPhieuUng = c.String(maxLength: 10),
                        LuongPhuTroi = c.Single(nullable: false),
                        LuongCoBan = c.Single(nullable: false),
                        TongLuong = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaBangLuong)
                .ForeignKey("dbo.BangLuongs", t => t.MaBangLuong)
                .ForeignKey("dbo.KyLuongs", t => t.MaKyLuong, cascadeDelete: true)
                .ForeignKey("dbo.NhanViens", t => t.MaNhanVien, cascadeDelete: true)
                .ForeignKey("dbo.PhieuUngLuongs", t => t.MaPhieuUng)
                .ForeignKey("dbo.PhuCaps", t => t.MaPhuCap)
                .Index(t => t.MaBangLuong)
                .Index(t => t.MaKyLuong)
                .Index(t => t.MaNhanVien)
                .Index(t => t.MaPhuCap)
                .Index(t => t.MaPhieuUng);
            
            CreateTable(
                "dbo.BangLuongs",
                c => new
                    {
                        MaBangLuong = c.String(nullable: false, maxLength: 10),
                        NgayPhatLuong = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaBangLuong);
            
            CreateTable(
                "dbo.KyLuongs",
                c => new
                    {
                        MaKyLuong = c.String(nullable: false, maxLength: 8),
                        Thang = c.Int(nullable: false),
                        Nam = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaKyLuong);
            
            CreateTable(
                "dbo.PhieuUngLuongs",
                c => new
                    {
                        MaPhieuUng = c.String(nullable: false, maxLength: 10),
                        MaNhanVien = c.String(nullable: false, maxLength: 10),
                        MucUngLuong = c.Single(nullable: false),
                        NgayUng = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhieuUng)
                .ForeignKey("dbo.NhanViens", t => t.MaNhanVien, cascadeDelete: true)
                .Index(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.PhuCaps",
                c => new
                    {
                        MaPhuCap = c.String(nullable: false, maxLength: 10),
                        TenPhuCap = c.String(nullable: false, maxLength: 250),
                        MucPhuCap = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhuCap);
            
            CreateTable(
                "dbo.CTPhuCaps",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 10),
                        MaPhuCap = c.String(nullable: false, maxLength: 10),
                        ThoiHan = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.HopDongs", t => t.MaHD)
                .ForeignKey("dbo.PhuCaps", t => t.MaPhuCap, cascadeDelete: true)
                .Index(t => t.MaHD)
                .Index(t => t.MaPhuCap);
            
            CreateTable(
                "dbo.HopDongs",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 10),
                        MaPhongBan = c.String(nullable: false, maxLength: 10),
                        MaNhanVien = c.String(nullable: false, maxLength: 10),
                        MaChucVu = c.String(nullable: false, maxLength: 10),
                        MaQuyetDinh = c.String(nullable: false, maxLength: 128),
                        IDHD = c.Int(nullable: false),
                        MaCheDo = c.String(nullable: false, maxLength: 10),
                        NgayKy = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.CheDoLamViecs", t => t.MaCheDo, cascadeDelete: true)
                .ForeignKey("dbo.ChucVus", t => t.MaChucVu, cascadeDelete: true)
                .ForeignKey("dbo.LoaiHDs", t => t.IDHD, cascadeDelete: true)
                .ForeignKey("dbo.NhanViens", t => t.MaNhanVien, cascadeDelete: true)
                .ForeignKey("dbo.PhongBans", t => t.MaPhongBan, cascadeDelete: true)
                .ForeignKey("dbo.QuyetDinhs", t => t.MaQuyetDinh, cascadeDelete: true)
                .Index(t => t.MaPhongBan)
                .Index(t => t.MaNhanVien)
                .Index(t => t.MaChucVu)
                .Index(t => t.MaQuyetDinh)
                .Index(t => t.IDHD)
                .Index(t => t.MaCheDo);
            
            CreateTable(
                "dbo.CheDoLamViecs",
                c => new
                    {
                        MaCheDo = c.String(nullable: false, maxLength: 10),
                        TimeLam1Day = c.String(nullable: false, maxLength: 10),
                        TimeLam1Week = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.MaCheDo);
            
            CreateTable(
                "dbo.ChucVus",
                c => new
                    {
                        MaChucVu = c.String(nullable: false, maxLength: 10),
                        TenChuCVu = c.String(nullable: false, maxLength: 250),
                        PhuCapCV = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaChucVu);
            
            CreateTable(
                "dbo.BaoHiemNhanViens",
                c => new
                    {
                        MaBH = c.String(nullable: false, maxLength: 10),
                        ID = c.Int(nullable: false),
                        MaHD = c.String(nullable: false, maxLength: 10),
                        MucDong = c.Single(nullable: false),
                        NgayDong = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaBH)
                .ForeignKey("dbo.BaoHiems", t => t.ID, cascadeDelete: true)
                .ForeignKey("dbo.HopDongs", t => t.MaHD, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.MaHD);
            
            CreateTable(
                "dbo.BaoHiems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenBH = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LoaiHDs",
                c => new
                    {
                        IDHD = c.Int(nullable: false, identity: true),
                        TenHopDong = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.IDHD);
            
            CreateTable(
                "dbo.PhongBans",
                c => new
                    {
                        MaPhongBan = c.String(nullable: false, maxLength: 10),
                        TenPhongBan = c.String(nullable: false, maxLength: 250),
                        PhuCapPB = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhongBan);
            
            CreateTable(
                "dbo.QuyetDinhs",
                c => new
                    {
                        MaQuyetDinh = c.String(nullable: false, maxLength: 128),
                        TenQuyetDinh = c.String(nullable: false, maxLength: 250),
                        NgayQuyetDinh = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaQuyetDinh);
            
            CreateTable(
                "dbo.NghiPheps",
                c => new
                    {
                        MaNghiPhep = c.String(nullable: false, maxLength: 10),
                        MaNhanVien = c.String(nullable: false, maxLength: 10),
                        NgayNghi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaNghiPhep)
                .ForeignKey("dbo.NhanViens", t => t.MaNhanVien, cascadeDelete: true)
                .Index(t => t.MaNhanVien);
            
            CreateTable(
                "dbo.PhieuPhuTrois",
                c => new
                    {
                        MaPhieuPT = c.String(nullable: false, maxLength: 10),
                        NgayPT = c.DateTime(nullable: false),
                        SoGioPT = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaPhieuPT);
            
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        IdTaiKhoan = c.String(nullable: false, maxLength: 10),
                        TaiKhoanName = c.String(nullable: false, maxLength: 250),
                        MatKhau = c.String(nullable: false, maxLength: 250),
                        TenNhanVien = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.IdTaiKhoan);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CTBangCongs", "MaPhieuPT", "dbo.PhieuPhuTrois");
            DropForeignKey("dbo.NghiPheps", "MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.CTPhuCaps", "MaPhuCap", "dbo.PhuCaps");
            DropForeignKey("dbo.HopDongs", "MaQuyetDinh", "dbo.QuyetDinhs");
            DropForeignKey("dbo.HopDongs", "MaPhongBan", "dbo.PhongBans");
            DropForeignKey("dbo.HopDongs", "MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.HopDongs", "IDHD", "dbo.LoaiHDs");
            DropForeignKey("dbo.BaoHiemNhanViens", "MaHD", "dbo.HopDongs");
            DropForeignKey("dbo.BaoHiemNhanViens", "ID", "dbo.BaoHiems");
            DropForeignKey("dbo.CTPhuCaps", "MaHD", "dbo.HopDongs");
            DropForeignKey("dbo.HopDongs", "MaChucVu", "dbo.ChucVus");
            DropForeignKey("dbo.HopDongs", "MaCheDo", "dbo.CheDoLamViecs");
            DropForeignKey("dbo.CTBangLuongs", "MaPhuCap", "dbo.PhuCaps");
            DropForeignKey("dbo.PhieuUngLuongs", "MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.CTBangLuongs", "MaPhieuUng", "dbo.PhieuUngLuongs");
            DropForeignKey("dbo.CTBangLuongs", "MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.CTBangLuongs", "MaKyLuong", "dbo.KyLuongs");
            DropForeignKey("dbo.BangCongs", "MaKyLuong", "dbo.KyLuongs");
            DropForeignKey("dbo.CTBangLuongs", "MaBangLuong", "dbo.BangLuongs");
            DropForeignKey("dbo.CTBangCongs", "MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.CTBangCongs", "MaLoaiCong", "dbo.LoaiCongs");
            DropForeignKey("dbo.CTBangCongs", "MaLoaiCa", "dbo.LoaiCas");
            DropForeignKey("dbo.CTBangCongs", "MaBangCong", "dbo.BangCongs");
            DropIndex("dbo.NghiPheps", new[] { "MaNhanVien" });
            DropIndex("dbo.BaoHiemNhanViens", new[] { "MaHD" });
            DropIndex("dbo.BaoHiemNhanViens", new[] { "ID" });
            DropIndex("dbo.HopDongs", new[] { "MaCheDo" });
            DropIndex("dbo.HopDongs", new[] { "IDHD" });
            DropIndex("dbo.HopDongs", new[] { "MaQuyetDinh" });
            DropIndex("dbo.HopDongs", new[] { "MaChucVu" });
            DropIndex("dbo.HopDongs", new[] { "MaNhanVien" });
            DropIndex("dbo.HopDongs", new[] { "MaPhongBan" });
            DropIndex("dbo.CTPhuCaps", new[] { "MaPhuCap" });
            DropIndex("dbo.CTPhuCaps", new[] { "MaHD" });
            DropIndex("dbo.PhieuUngLuongs", new[] { "MaNhanVien" });
            DropIndex("dbo.CTBangLuongs", new[] { "MaPhieuUng" });
            DropIndex("dbo.CTBangLuongs", new[] { "MaPhuCap" });
            DropIndex("dbo.CTBangLuongs", new[] { "MaNhanVien" });
            DropIndex("dbo.CTBangLuongs", new[] { "MaKyLuong" });
            DropIndex("dbo.CTBangLuongs", new[] { "MaBangLuong" });
            DropIndex("dbo.CTBangCongs", new[] { "MaPhieuPT" });
            DropIndex("dbo.CTBangCongs", new[] { "MaLoaiCong" });
            DropIndex("dbo.CTBangCongs", new[] { "MaLoaiCa" });
            DropIndex("dbo.CTBangCongs", new[] { "MaNhanVien" });
            DropIndex("dbo.CTBangCongs", new[] { "MaBangCong" });
            DropIndex("dbo.BangCongs", new[] { "MaKyLuong" });
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.PhieuPhuTrois");
            DropTable("dbo.NghiPheps");
            DropTable("dbo.QuyetDinhs");
            DropTable("dbo.PhongBans");
            DropTable("dbo.LoaiHDs");
            DropTable("dbo.BaoHiems");
            DropTable("dbo.BaoHiemNhanViens");
            DropTable("dbo.ChucVus");
            DropTable("dbo.CheDoLamViecs");
            DropTable("dbo.HopDongs");
            DropTable("dbo.CTPhuCaps");
            DropTable("dbo.PhuCaps");
            DropTable("dbo.PhieuUngLuongs");
            DropTable("dbo.KyLuongs");
            DropTable("dbo.BangLuongs");
            DropTable("dbo.CTBangLuongs");
            DropTable("dbo.NhanViens");
            DropTable("dbo.LoaiCongs");
            DropTable("dbo.LoaiCas");
            DropTable("dbo.CTBangCongs");
            DropTable("dbo.BangCongs");
        }
    }
}
