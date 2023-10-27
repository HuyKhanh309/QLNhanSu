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
    public partial class frmLoaiCa : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaiCa()
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
            tbMaLoaiCa.ReadOnly = check;
            tbTenLoaiCa.ReadOnly = check;
            tbMoTa.ReadOnly = check;
        }
        private void frmLoaiCa_Load(object sender, EventArgs e)
        {
            turn_on_off(true);
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            LoadDataGridView();
        }

        private List<LoaiCa> GetData()
        {
            List<LoaiCa> list = new List<LoaiCa>();
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            list = dbContext.LoaiCas.ToList();
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
                    string maca = dongChon.Cells[0].Value.ToString();
                    string tenca = dongChon.Cells[1].Value.ToString();
                    string mota = dongChon.Cells[2].Value.ToString();

                    tbMaLoaiCa.Text = maca;
                    tbTenLoaiCa.Text = tenca;
                    tbMoTa.Text = mota;
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
                string maca = dongChon.Cells[0].Value.ToString();
                string tenca = dongChon.Cells[1].Value.ToString();
                string mota = dongChon.Cells[2].Value.ToString();

                tbMaLoaiCa.Text = maca;
                tbTenLoaiCa.Text = tenca;
                tbMoTa.Text = mota;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            //Clear text box
            tbMaLoaiCa.Clear();
            tbTenLoaiCa.Clear();
            tbMoTa.Clear();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            tbMaLoaiCa.ReadOnly = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
                var del = dbContext.LoaiCas.Find(tbMaLoaiCa.Text);
                if (del != null)
                {
                    dbContext.LoaiCas.Remove(del);
                    dbContext.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ca", "Thông báo", MessageBoxButtons.OK);
                }
                LoadDataGridView();
                tbMaLoaiCa.Clear();
                tbTenLoaiCa.Clear();
                tbMoTa.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Lỗi: ");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                QLNhanSuDBContext dbContext = new QLNhanSuDBContext();

                if (tbMaLoaiCa.ReadOnly == true)
                {
                    //Sửa
                    LoaiCa edit = dbContext.LoaiCas.Find(tbMaLoaiCa.Text);
                    if (edit == null)
                    {
                        MessageBox.Show("Loại ca không tồn tại");
                    }
                    else
                    {
                        edit.TenLoaiCa = tbTenLoaiCa.Text;
                        edit.MoTa = tbMoTa.Text;
                        dbContext.Entry<LoaiCa>(edit).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                        MessageBox.Show("Lưu thông tin thành công");

                    }
                }
                else
                {
                    //Thêm
                    LoaiCa checkExit = dbContext.LoaiCas.Find(tbMaLoaiCa.Text);
                    if (checkExit != null)
                    {
                        MessageBox.Show("Mã ca đã tồn tại");
                    }
                    else
                    {

                        LoaiCa ca = new LoaiCa();
                        ca.MaLoaiCa = tbMaLoaiCa.Text;
                        ca.TenLoaiCa = tbTenLoaiCa.Text;
                        ca.MoTa = tbMoTa.Text;
                        dbContext.LoaiCas.Add(ca);
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

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            turn_on_off(true);
            LoadDataGridView();
        }

        void search()
        {

            string maca = scTimIDLoaiCa.Text;
            string tenca = scTimTenLoaiCa.Text;
            var list = GetData().Where(s => s.MaLoaiCa.StartsWith(maca) && s.TenLoaiCa.StartsWith(tenca)).ToList();

            dgv.DataSource = null;
            dgv.DataSource = list;
        }


        private void scTimTenLoaiCa_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void scTimIDLoaiCa_TextChanged(object sender, EventArgs e)
        {
            search();
        }
    }
}