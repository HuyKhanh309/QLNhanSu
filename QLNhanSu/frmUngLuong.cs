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
    public partial class frmUngLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmUngLuong()
        {
            InitializeComponent();
            
            // Activate advanced mode.
            tbTenNhanVien.Properties.UseAdvancedMode = DevExpress.Utils.DefaultBoolean.True;
            tbTenNhanVien.Properties.AdvancedModeOptions.AutoCompleteMode = DevExpress.XtraEditors.TextEditAutoCompleteMode.SuggestAppend;
            // Enable custom auto-complete suggestions.
            tbTenNhanVien.Properties.AdvancedModeOptions.AutoCompleteSource = AutoCompleteSource.CustomSource;
            // Supply the custom auto-complete suggestions.
            
        }
        private void tbTenNhanVien_TextChanged(object sender, EventArgs e)
        {
            QLNhanSuDBContext dBContext = new QLNhanSuDBContext();
            AutoCompleteStringCollection list = new AutoCompleteStringCollection();
            List<string> hoTen = dBContext.NhanViens.Select(s=> s.HoTen).ToList();
            list.AddRange(hoTen.ToArray());
            tbTenNhanVien.Properties.AdvancedModeOptions.AutoCompleteCustomSource = list;
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
            tbIDPhieuUng.ReadOnly = check;
            tbTenNhanVien.ReadOnly = check;
            tbLuongUng.ReadOnly = check;
            dtNgayUng.Enabled = !check;
        }
        private void frmUngLuong_Load(object sender, EventArgs e)
        {
            turn_on_off(true);
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            LoadDataGridView();
        }
        private List<UngLuongView> GetData()
        {
            List<PhieuUngLuong> list = new List<PhieuUngLuong>();
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            list = dbContext.PhieuUngLuongs.ToList();
            List<UngLuongView> view = new List<UngLuongView>();
            view = list.Select(s => new UngLuongView
            {
                MaPhieuUng = s.MaPhieuUng,
                TenNhanVien = s.NhanVien.HoTen,
                MucUngLuong= s.MucUngLuong,
                NgayUng = s.NgayUng.ToString("dd/MM/yyyy"),
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
                    string maPhieuUng = dongChon.Cells[0].Value.ToString();
                    string tenNhanVien = dongChon.Cells[1].Value.ToString();
                    string luongUng = dongChon.Cells[2].Value.ToString();
                    string ngayUng = dongChon.Cells[3].Value.ToString();

                    tbIDPhieuUng.Text = maPhieuUng;
                    tbTenNhanVien.Text = tenNhanVien;
                    tbLuongUng.Text = luongUng;
                    dtNgayUng.Text = ngayUng;
                }
            }
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = dgv.CurrentCell.RowIndex;

            if (index >= 0)
            {
                var dongChon = dgv.Rows[index];
                //Đi vào từng cột
                string maPhieuUng = dongChon.Cells[0].Value.ToString();
                string tenNhanVien = dongChon.Cells[1].Value.ToString();
                string luongUng = dongChon.Cells[2].Value.ToString();
                string ngayUng = dongChon.Cells[3].Value.ToString();

                tbIDPhieuUng.Text = maPhieuUng;
                tbTenNhanVien.Text = tenNhanVien;
                tbLuongUng.Text = luongUng;
                dtNgayUng.Text = ngayUng;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            //Clear text box
            tbIDPhieuUng.Clear();
            tbTenNhanVien.Clear();
            tbLuongUng.Clear();
            dtNgayUng.Clear();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            tbIDPhieuUng.ReadOnly = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try { 
                QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
                var del = dbContext.PhieuUngLuongs.Find(tbIDPhieuUng.Text);
                if (del != null)
                {
                    dbContext.PhieuUngLuongs.Remove(del);
                    dbContext.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kỳ lương", "Thông báo", MessageBoxButtons.OK);
                }
                LoadDataGridView();
                tbIDPhieuUng.Clear();
                tbTenNhanVien.Clear();
                tbLuongUng.Clear();
                dtNgayUng.Clear();
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

                if (tbIDPhieuUng.ReadOnly == true)
                {
                    //Sửa
                    PhieuUngLuong edit = dbContext.PhieuUngLuongs.Find(tbIDPhieuUng.Text);
                    if (edit == null)
                    {
                        MessageBox.Show("Phiếu ứng lương không tồn tại");
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
                        edit.MucUngLuong = float.Parse(tbLuongUng.Text);
                        edit.NgayUng= DateTime.Parse(DateTime.ParseExact(dtNgayUng.Text, "dd/MM/yyyy", null).ToString("yyyy-MM-dd"));
                        dbContext.Entry<PhieuUngLuong>(edit).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                        MessageBox.Show("Lưu thông tin thành công");

                    }
                }
                else
                {
                    //Thêm
                    PhieuUngLuong checkExit = dbContext.PhieuUngLuongs.Find(tbIDPhieuUng.Text);
                    if (checkExit != null)
                    {
                        MessageBox.Show("Phiếu ứng lương đã tồn tại");
                    }
                    else
                    {
                        PhieuUngLuong phieuUng = new PhieuUngLuong();
                        NhanVien nv = dbContext.NhanViens.ToList().Where(s => s.HoTen == tbTenNhanVien.Text).FirstOrDefault();
                        if (nv == null)
                        {
                            MessageBox.Show("Tên nhân viên không tồn tại", "Lỗi: ");
                            return;
                        }
                        phieuUng.MaPhieuUng = tbIDPhieuUng.Text;
                        phieuUng.MaNhanVien = nv.MaNhanVien;
                        phieuUng.MucUngLuong = float.Parse(tbLuongUng.Text);
                        phieuUng.NgayUng = DateTime.Parse(DateTime.ParseExact(dtNgayUng.Text, "dd/MM/yyyy", null).ToString("yyyy-MM-dd"));
                        dbContext.Entry<PhieuUngLuong>(phieuUng).State = System.Data.Entity.EntityState.Modified;
                        dbContext.PhieuUngLuongs.Add(phieuUng);
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

            string maPhieuUng = scTimIDPhieuUng.Text;
            string tenNhanVien = scTimTenNhanVien.Text;
            var list = GetData().Where(s => s.MaPhieuUng.StartsWith(maPhieuUng)&& s.TenNhanVien.StartsWith(tenNhanVien)).ToList();

            dgv.DataSource = null;
            dgv.DataSource = list;
        }

        private void scTimIDPhieuUng_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void scTimTenNhanVien_TextChanged(object sender, EventArgs e)
        {
            search();
        }


    }
}