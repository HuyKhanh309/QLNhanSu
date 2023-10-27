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
    public partial class frmKyLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmKyLuong()
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
            tbMaKyLuong.ReadOnly = check;
            dtThoiGian.ReadOnly = check;
        }
        private void frmKyLuong_Load(object sender, EventArgs e)
        {
            turn_on_off(true);
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            LoadDataGridView();
        }
        private List<KyLuong> GetData()
        {
            List<KyLuong> list = new List<KyLuong>();
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            list = dbContext.KyLuongs.ToList();
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
                    string makl = dongChon.Cells[0].Value.ToString();
                    string thang = dongChon.Cells[1].Value.ToString();
                    string nam = dongChon.Cells[2].Value.ToString();

                    tbMaKyLuong.Text = makl;
                    dtThoiGian.Text = DateTime.Parse(thang + "/" + nam).ToString("MM/yyyy");
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
                string makl = dongChon.Cells[0].Value.ToString();
                string thang = dongChon.Cells[1].Value.ToString();
                string nam = dongChon.Cells[2].Value.ToString();

                tbMaKyLuong.Text = makl;
                dtThoiGian.Text = DateTime.Parse(thang + "/" + nam).ToString("MM/yyyy");
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            //Clear text box
            tbMaKyLuong.Clear();
            dtThoiGian.Clear();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            tbMaKyLuong.ReadOnly = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
                var del = dbContext.KyLuongs.Find(tbMaKyLuong.Text);
                if (del != null)
                {
                    dbContext.KyLuongs.Remove(del);
                    dbContext.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kỳ lương", "Thông báo", MessageBoxButtons.OK);
                }
                LoadDataGridView();
                tbMaKyLuong.Clear();
                dtThoiGian.Clear();
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

                if (tbMaKyLuong.ReadOnly == true)
                {
                    //Sửa
                    KyLuong edit = dbContext.KyLuongs.Find(tbMaKyLuong.Text);
                    if (edit == null)
                    {
                        MessageBox.Show("Kỳ lương không tồn tại");
                    }
                    else
                    {
                        edit.Thang = DateTime.Parse(dtThoiGian.Text).Month;
                        edit.Nam = DateTime.Parse(dtThoiGian.Text).Year;
                        dbContext.Entry<KyLuong>(edit).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                        MessageBox.Show("Lưu thông tin thành công");

                    }
                }
                else
                {
                    //Thêm
                    LoaiCa checkExit = dbContext.LoaiCas.Find(tbMaKyLuong.Text);
                    if (checkExit != null)
                    {
                        MessageBox.Show("Kỳ lương đã tồn tại");
                    }
                    else
                    {

                        KyLuong kyLuong = new KyLuong();
                        kyLuong.MaKyLuong = tbMaKyLuong.Text;
                        kyLuong.Thang = DateTime.Parse(dtThoiGian.Text).Month;
                        kyLuong.Nam = DateTime.Parse(dtThoiGian.Text).Year;
                        dbContext.KyLuongs.Add(kyLuong);
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

            string makyluong = scTimIDKyLuong.Text;
            var list = GetData().Where(s => s.MaKyLuong.StartsWith(makyluong) ).ToList();

            dgv.DataSource = null;
            dgv.DataSource = list;
        }

        private void scTimIDLoaiCong_TextChanged(object sender, EventArgs e)
        {
            search();
        }



    }
}