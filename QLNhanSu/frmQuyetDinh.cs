using DevExpress.XtraEditors;
using QLNhanSu.Models;
using QLNhanSu.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNhanSu
{
    public partial class frmQuyetDinh : DevExpress.XtraEditors.XtraForm
    {
        public frmQuyetDinh()
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
            tbIDQuyetDinh.ReadOnly = check;
            tbTenQuyetDinh.ReadOnly = check;
            dtNgayQuyetDinh.Enabled = !check;
        }

        private void frmQuyetDinh_Load(object sender, EventArgs e)
        {
            turn_on_off(true);
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            LoadDataGridView();
        }
        private List<QuyetDinhView> GetData()
        {
            List<QuyetDinh> list = new List<QuyetDinh>();
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            list = dbContext.QuyetDinhs.ToList();
            List<QuyetDinhView> view = new List<QuyetDinhView>();
            view = list.Select(s => new QuyetDinhView
            {
                MaQuyetDinh = s.MaQuyetDinh,
                TenQuyetDinh = s.TenQuyetDinh,
                NgayQuyetDinh = s.NgayQuyetDinh.ToString("dd/MM/yyyy"),
            }).ToList();
            return view;
        }
        private void LoadDataGridView()
        {
            dgv.DataSource = null;
            dgv.DataSource = GetData();

            var index = dgv.CurrentCell.RowIndex;
            if (dgv.CurrentCell != null)
            {
                if (index >= 0)
                {
                    var dongChon = dgv.Rows[index];
                    //Đi vào từng cột
                    string maqd = dongChon.Cells[0].Value.ToString();
                    string tenqd = dongChon.Cells[1].Value.ToString();
                    string thoigianqd = dongChon.Cells[2].Value.ToString();

                    tbIDQuyetDinh.Text = maqd;
                    tbTenQuyetDinh.Text = tenqd;
                    dtNgayQuyetDinh.Text = thoigianqd;
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
                string maqd = dongChon.Cells[0].Value.ToString();
                string tenqd = dongChon.Cells[1].Value.ToString();
                string thoigianqd = dongChon.Cells[2].Value.ToString();

                tbIDQuyetDinh.Text = maqd;
                tbTenQuyetDinh.Text = tenqd;
                dtNgayQuyetDinh.Text = thoigianqd;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            //Clear text box
            tbIDQuyetDinh.Clear();
            tbTenQuyetDinh.Clear();
            dtNgayQuyetDinh.Clear();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            tbIDQuyetDinh.ReadOnly = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
                var del = dbContext.QuyetDinhs.Find(tbIDQuyetDinh.Text);
                if (del != null)
                {
                    dbContext.QuyetDinhs.Remove(del);
                    dbContext.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy quyết định", "Thông báo", MessageBoxButtons.OK);
                }
                LoadDataGridView();
                tbIDQuyetDinh.Clear();
                tbTenQuyetDinh.Clear();
                dtNgayQuyetDinh.Clear();
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

                if (tbIDQuyetDinh.ReadOnly == true)
                {
                    //Sửa
                    QuyetDinh edit = dbContext.QuyetDinhs.Find(tbIDQuyetDinh.Text);
                    if (edit == null)
                    {
                        MessageBox.Show("Quyết định không tồn tại");
                    }
                    else
                    {
                        edit.TenQuyetDinh = tbTenQuyetDinh.Text;
                        edit.NgayQuyetDinh = DateTime.Parse(DateTime.ParseExact(dtNgayQuyetDinh.Text, "dd/MM/yyyy", null).ToString("yyyy-MM-dd"));
                        dbContext.Entry<QuyetDinh>(edit).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                        MessageBox.Show("Lưu thông tin thành công");

                    }
                }
                else
                {
                    //Thêm
                    QuyetDinh checkExit = dbContext.QuyetDinhs.Find(tbIDQuyetDinh.Text);
                    if (checkExit != null)
                    {
                        MessageBox.Show("Mã quyết định đã tồn tại");
                    }
                    else
                    {

                        QuyetDinh quyetDinh = new QuyetDinh();
                        quyetDinh.MaQuyetDinh = tbIDQuyetDinh.Text;
                        quyetDinh.TenQuyetDinh = tbTenQuyetDinh.Text;
                        quyetDinh.NgayQuyetDinh = DateTime.Parse(DateTime.ParseExact(dtNgayQuyetDinh.Text, "dd/MM/yyyy", null).ToString("yyyy-MM-dd"));
                        dbContext.QuyetDinhs.Add(quyetDinh);
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

            string maqd = scTimIDQuyetDinh.Text;
            string tenqd = scTimTenQuyetDinh.Text;
            var list = GetData().Where(s => s.MaQuyetDinh.StartsWith(maqd) && s.TenQuyetDinh.StartsWith(tenqd)).ToList();

            dgv.DataSource = null;
            dgv.DataSource = list;
        }

        private void scTimIDQuyetDinh_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void scTimTenQuyetDinh_TextChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}