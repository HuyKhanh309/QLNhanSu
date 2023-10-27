using DevExpress.XtraEditors;
using QLNhanSu.Models;
using QLNhanSu.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class frmHopDong : DevExpress.XtraEditors.XtraForm
    {
        public frmHopDong()
        {
            InitializeComponent();
            // Activate advanced mode.
            tbTenNhanVien.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
            tbTenNhanVien.Properties.AdvancedModeOptions.AutoCompleteMode = DevExpress.XtraEditors.TextEditAutoCompleteMode.SuggestAppend;
            // Enable custom auto-complete suggestions.
            tbTenNhanVien.Properties.AdvancedModeOptions.AutoCompleteSource = AutoCompleteSource.CustomSource;
            // Supply the custom auto-complete suggestions.
        }
        private void turn_on_off(bool check)
        {
            //nút chức năng
            btnThem.Enabled = check;
            btnSua.Enabled = check;
            btnXoa.Enabled = check;
            btnLuu.Enabled = !check;
            btnHuy.Enabled = !check;
            //text box nhập xuất
            tbIDHopDong.ReadOnly = check;
            tbTenNhanVien.ReadOnly = check;
            cbCheDo.Enabled = !check;
            cbChucVu.Enabled = !check;
            cbLoaiHD.Enabled = !check;
            cbPhongBan.Enabled = !check;
            cbQuyetDinh.Enabled = !check;
            dtNgayKy.Enabled = !check;
        }
        private void frmHopDong_Load(object sender, EventArgs e)
        {
            turn_on_off(true);
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            List<PhongBan> listPhongBan = dbContext.PhongBans.ToList();
            List<ChucVu> listChucVu = dbContext.ChucVus.ToList();
            List<QuyetDinh> listQuyetDinh = dbContext.QuyetDinhs.ToList();
            List<LoaiHD> listLoaiHD = dbContext.LoaiHDs.ToList();
            List<CheDoLamViec> listCheDo = dbContext.CheDoLamViecs.ToList();
            fillcbbPhongBan(listPhongBan);
            fillcbbChucVu(listChucVu);
            fillcbbQuyetDinh(listQuyetDinh);
            fillcbbLoaiHD(listLoaiHD);
            fillcbbCheDo(listCheDo);
            LoadDataGridView();
        }
        private void tbTenNhanVien_TextChanged(object sender, EventArgs e)
        {
            QLNhanSuDBContext dBContext = new QLNhanSuDBContext();
            AutoCompleteStringCollection list = new AutoCompleteStringCollection();
            List<string> hoTen = dBContext.NhanViens.Select(s => s.HoTen).ToList();
            list.AddRange(hoTen.ToArray());
            tbTenNhanVien.Properties.AdvancedModeOptions.AutoCompleteCustomSource = list;
        }

        private void fillcbbQuyetDinh(List<QuyetDinh> listQuyetDinh)
        {
            cbQuyetDinh.DataSource = listQuyetDinh;
            cbQuyetDinh.DisplayMember = "TenQuyetDinh";
            cbQuyetDinh.ValueMember = "MaQuyetDinh";
        }

        private void fillcbbPhongBan(List<PhongBan> listPhongBan)
        {
            cbPhongBan.DataSource = listPhongBan;
            cbPhongBan.DisplayMember = "TenPhongBan";
            cbPhongBan.ValueMember = "MaPhongBan";
        }

        private void fillcbbLoaiHD(List<LoaiHD> listLoaiHD)
        {
            cbLoaiHD.DataSource = listLoaiHD;
            cbLoaiHD.DisplayMember = "TenHopDong";
            cbLoaiHD.ValueMember = "IDHD";
        }

        private void fillcbbChucVu(List<ChucVu> listChucVu)
        {
            cbChucVu.DataSource = listChucVu;
            cbChucVu.DisplayMember = "TenChuCVu";
            cbChucVu.ValueMember = "MaChucVu";
        }

        private void fillcbbCheDo(List<CheDoLamViec> listCheDo)
        {
            cbCheDo.DataSource = listCheDo;
            cbCheDo.DisplayMember = "TimeLam1Day";
            cbCheDo.ValueMember = "MaCheDo";
        }

        private List<HopDongView> GetData()
        {
            List<HopDong> list = new List<HopDong>();
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            list = dbContext.HopDongs.ToList();
            List<HopDongView> view = new List<HopDongView>();
            view = list.Select(s => new HopDongView
            {
                MaHD = s.MaHD,
                TenNhanVien = s.NhanVien.HoTen,
                ChucVu = s.ChucVu.TenChuCVu,
                CheDo = s.CheDoLamViec.TimeLam1Day,
                PhongBan = s.PhongBan.TenPhongBan,
                LoaiHD = s.LoaiHD.TenHopDong,
                QuyetDinh=s.QuyetDinh.TenQuyetDinh,
                NgayKy = s.NgayKy ,
            }).ToList();
            return view;
        }
        private void LoadDataGridView()
        {
            dgv.DataSource = null;
            dgv.DataSource = GetData();


            if (dgv.CurrentCell != null)
            {
                var index = dgv.CurrentCell.RowIndex;
                if (index >= 0)
                {
                    var dongChon = dgv.Rows[index];
                    //Đi vào từng cột
                    string mahd = dongChon.Cells[0].Value.ToString();
                    string tennv = dongChon.Cells[1].Value.ToString();
                    string phongBan = dongChon.Cells[2].Value.ToString();
                    string chucVu = dongChon.Cells[3].Value.ToString();
                    string quyetDinh = dongChon.Cells[4].Value.ToString();
                    string loaiHD = dongChon.Cells[5].Value.ToString();
                    string cheDo = dongChon.Cells[6].Value.ToString();
                    string ngayKy = dongChon.Cells[7].Value.ToString();

                    tbIDHopDong.Text = mahd;
                    tbTenNhanVien.Text = tennv;
                    cbPhongBan.Text = phongBan;
                    cbChucVu.Text = chucVu;
                    cbQuyetDinh.Text = quyetDinh;
                    cbLoaiHD.Text = loaiHD;
                    cbCheDo.Text = cheDo;
                    dtNgayKy.Text = ngayKy;
                }
            }
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentCell != null)
            {
                var index = dgv.CurrentCell.RowIndex;
                if (index >= 0)
                {
                    var dongChon = dgv.Rows[index];
                    //Đi vào từng cột
                    string mahd = dongChon.Cells[0].Value.ToString();
                    string tennv = dongChon.Cells[1].Value.ToString();
                    string phongBan = dongChon.Cells[2].Value.ToString();
                    string chucVu = dongChon.Cells[3].Value.ToString();
                    string quyetDinh = dongChon.Cells[4].Value.ToString();
                    string loaiHD = dongChon.Cells[5].Value.ToString();
                    string cheDo = dongChon.Cells[6].Value.ToString();
                    string ngayKy = dongChon.Cells[7].Value.ToString();

                    tbIDHopDong.Text = mahd;
                    tbTenNhanVien.Text = tennv;
                    cbPhongBan.Text = phongBan;
                    cbChucVu.Text = chucVu;
                    cbQuyetDinh.Text = quyetDinh;
                    cbLoaiHD.Text = loaiHD;
                    cbCheDo.Text = cheDo;
                    dtNgayKy.Text = ngayKy;
                }
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            //Clear text box
            tbIDHopDong.Clear();
            tbTenNhanVien.Clear();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            tbIDHopDong.ReadOnly = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
                var del = dbContext.HopDongs.Find(tbIDHopDong.Text);
                if (del != null)
                {
                    dbContext.HopDongs.Remove(del);
                    dbContext.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy quyết định", "Thông báo", MessageBoxButtons.OK);
                }
                LoadDataGridView();
                tbIDHopDong.Clear();
                tbTenNhanVien.Clear();
                dtNgayKy.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Lỗi: ");
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                QLNhanSuDBContext dbContext = new QLNhanSuDBContext();

                if (tbIDHopDong.ReadOnly == true)
                {
                    //Sửa
                    HopDong edit = dbContext.HopDongs.Find(tbIDHopDong.Text);
                    if (edit == null)
                    {
                        MessageBox.Show("Hợp đồng không tồn tại");
                    }
                    else
                    {
                        NhanVien nv = dbContext.NhanViens.ToList().Where(s => s.HoTen == tbTenNhanVien.Text).FirstOrDefault();
                        if (nv == null)
                        {
                            MessageBox.Show("Tên nhân viên không tồn tại", "Lỗi: ");
                            return;
                        }
                        edit.MaNhanVien = nv.MaNhanVien;
                        //MessageBox.Show(cbCheDo.SelectedValue.ToString());
                        edit.MaCheDo = cbCheDo.SelectedValue.ToString();
                        edit.MaPhongBan = cbPhongBan.SelectedValue.ToString();
                        edit.MaChucVu = cbChucVu.SelectedValue.ToString();
                        edit.IDHD = int.Parse(cbLoaiHD.SelectedValue.ToString());
                        edit.MaQuyetDinh = cbQuyetDinh.SelectedValue.ToString();
                        edit.NgayKy = 1;
                        dbContext.Entry<HopDong>(edit).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                        MessageBox.Show("Lưu thông tin thành công");

                    }
                }
                else
                {
                    //Thêm
                    HopDong checkExit = dbContext.HopDongs.Find(tbIDHopDong.Text);
                    if (checkExit != null)
                    {
                        MessageBox.Show("Hợp đồng đã tồn tại");
                    }
                    else
                    {

                        HopDong hopDong = new HopDong();
                        NhanVien nv = dbContext.NhanViens.ToList().Where(s => s.HoTen == tbTenNhanVien.Text).FirstOrDefault();
                        if (nv == null)
                        {
                            MessageBox.Show("Tên nhân viên không tồn tại", "Lỗi: ");
                            return;
                        }
                        hopDong.MaHD = tbIDHopDong.Text;
                        hopDong.MaNhanVien = nv.MaNhanVien;
                        //MessageBox.Show(cbCheDo.SelectedValue.ToString());
                        hopDong.MaCheDo = cbCheDo.SelectedValue.ToString();
                        hopDong.MaPhongBan = cbPhongBan.SelectedValue.ToString();
                        hopDong.MaChucVu = cbChucVu.SelectedValue.ToString();
                        hopDong.IDHD = int.Parse(cbLoaiHD.SelectedValue.ToString());
                        hopDong.MaQuyetDinh = cbQuyetDinh.SelectedValue.ToString();
                        hopDong.NgayKy = 1;
                        dbContext.HopDongs.Add(hopDong);
                        dbContext.SaveChanges();
                        MessageBox.Show("Lưu thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Lỗi: ");
            }
            turn_on_off(true);
            LoadDataGridView();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            turn_on_off(true);
            LoadDataGridView();
        }

        void search()
        {

            string mahd = scTimIDHopDong.Text;
            string tennv = scTimTenNhanVien.Text;
            var list = GetData().Where(s => s.MaHD.StartsWith(mahd) && s.TenNhanVien.StartsWith(tennv)).ToList();

            dgv.DataSource = null;
            dgv.DataSource = list;
        }
        private void scTimIDHopDong_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void scTimTenNhanVien_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void cbPhongBan_Click(object sender, EventArgs e)
        {
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            List<PhongBan> listPhongBan = dbContext.PhongBans.ToList();
            fillcbbPhongBan(listPhongBan);
        }

        private void cbChucVu_Click(object sender, EventArgs e)
        {
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            List<ChucVu> listChucVu = dbContext.ChucVus.ToList();
            fillcbbChucVu(listChucVu);
        }

        private void cbQuyetDinh_Click(object sender, EventArgs e)
        {
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            List<QuyetDinh> listQuyetDinh = dbContext.QuyetDinhs.ToList();
            fillcbbQuyetDinh(listQuyetDinh);
        }

        private void cbLoaiHD_Click(object sender, EventArgs e)
        {
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            List<LoaiHD> listLoaiHD = dbContext.LoaiHDs.ToList();
            fillcbbLoaiHD(listLoaiHD);
        }

        private void cbCheDo_Click(object sender, EventArgs e)
        {
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            List<CheDoLamViec> listCheDo = dbContext.CheDoLamViecs.ToList();
            fillcbbCheDo(listCheDo);
        }

    }
}