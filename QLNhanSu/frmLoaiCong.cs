using DevExpress.XtraEditors;
using QLNhanSu.Models;
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
    public partial class frmLoaiCong : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaiCong()
        {
            InitializeComponent();

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
            tbMaLoaiCong.ReadOnly = check;
            tbTenLoaiCong.ReadOnly = check;
            tbHeSoLuong.ReadOnly = check;
        }
        private void frmLoaiCong_Load(object sender, EventArgs e)
        {
            turn_on_off(true);
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            LoadDataGridView();
        }
        private List<LoaiCong> GetData()
        {
            List<LoaiCong> list = new List<LoaiCong>();
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            list = dbContext.LoaiCongs.ToList();
            return list;
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
                    string macong = dongChon.Cells[0].Value.ToString();
                    string tencong = dongChon.Cells[1].Value.ToString();
                    string heso = dongChon.Cells[2].Value.ToString();

                    tbMaLoaiCong.Text = macong;
                    tbTenLoaiCong.Text = tencong;
                    tbHeSoLuong.Text = heso;
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
                string macong = dongChon.Cells[0].Value.ToString();
                string tencong = dongChon.Cells[1].Value.ToString();
                string heso = dongChon.Cells[2].Value.ToString();

                tbMaLoaiCong.Text = macong;
                tbTenLoaiCong.Text = tencong;
                tbHeSoLuong.Text = heso;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            //Clear text box
            tbMaLoaiCong.Clear();
            tbTenLoaiCong.Clear();
            tbHeSoLuong.Clear();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            tbMaLoaiCong.ReadOnly = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
                var del = dbContext.LoaiCongs.Find(tbMaLoaiCong.Text);
                if (del != null)
                {
                    dbContext.LoaiCongs.Remove(del);
                    dbContext.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ca", "Thông báo", MessageBoxButtons.OK);
                }
                LoadDataGridView();
                tbMaLoaiCong.Clear();
                tbTenLoaiCong.Clear();
                tbHeSoLuong.Clear();
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

                if (tbMaLoaiCong.ReadOnly == true)
                {
                    //Sửa
                    LoaiCong edit = dbContext.LoaiCongs.Find(tbMaLoaiCong.Text);
                    if (edit == null)
                    {
                        MessageBox.Show("Loại công không tồn tại");
                    }
                    else
                    {
                        edit.TenLoaiCong = tbTenLoaiCong.Text;
                        edit.HeSoLuong = float.Parse(tbHeSoLuong.Text);
                        dbContext.Entry<LoaiCong>(edit).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                        MessageBox.Show("Lưu thông tin thành công");

                    }
                }
                else
                {
                    //Thêm
                    LoaiCong checkExit = dbContext.LoaiCongs.Find(tbMaLoaiCong.Text);
                    if (checkExit != null)
                    {
                        MessageBox.Show("Ma công đã tồn tại");
                    }
                    else
                    {

                        LoaiCong cong = new LoaiCong();
                        cong.MaLoaiCong = tbMaLoaiCong.Text;
                        cong.TenLoaiCong = tbTenLoaiCong.Text;
                        cong.HeSoLuong = float.Parse(tbHeSoLuong.Text);
                        dbContext.LoaiCongs.Add(cong);
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

            string macong = scTimIDLoaiCong.Text;
            string tencong = scTimTenLoaiCong.Text;
            var list = GetData().Where(s => s.MaLoaiCong.StartsWith(macong) && s.TenLoaiCong.StartsWith(tencong)).ToList();

            dgv.DataSource = null;
            dgv.DataSource = list;
        }

        private void scTimIDLoaiCong_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void scTimTenLoaiCong_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        
    }
}