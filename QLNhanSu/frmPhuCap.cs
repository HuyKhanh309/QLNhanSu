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
    public partial class frmPhuCap : DevExpress.XtraEditors.XtraForm
    {
        public frmPhuCap()
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
            tbMaPhuCap.ReadOnly = check;
            tbTenPhuCap.ReadOnly = check;
            tbSoTien.ReadOnly = check;
        }
        private void frmPhuCap_Load(object sender, EventArgs e)
        {
            turn_on_off(true);
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            LoadDataGridView();
        }

        private List<PhuCap> GetData()
        {
            List<PhuCap> list = new List<PhuCap>();
            QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
            list = dbContext.PhuCaps.ToList();
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
                    string maphucap = dongChon.Cells[0].Value.ToString();
                    string tenphucap = dongChon.Cells[1].Value.ToString();
                    string sotien = dongChon.Cells[2].Value.ToString();

                    tbMaPhuCap.Text = maphucap;
                    tbTenPhuCap.Text = tenphucap;
                    tbSoTien.Text = sotien;
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
                string maphucap = dongChon.Cells[0].Value.ToString();
                string tenphucap = dongChon.Cells[1].Value.ToString();
                string sotien = dongChon.Cells[2].Value.ToString();

                tbMaPhuCap.Text = maphucap;
                tbTenPhuCap.Text = tenphucap;
                tbSoTien.Text = sotien;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            //Clear text box
            tbMaPhuCap.Clear();
            tbTenPhuCap.Clear();
            tbSoTien.Clear();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            turn_on_off(false);
            tbMaPhuCap.ReadOnly = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                QLNhanSuDBContext dbContext = new QLNhanSuDBContext();
                var del = dbContext.PhuCaps.Find(tbMaPhuCap.Text);
                if (del != null)
                {
                    dbContext.PhuCaps.Remove(del);
                    dbContext.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phụ cấp", "Thông báo", MessageBoxButtons.OK);
                }
                LoadDataGridView();
                tbMaPhuCap.Clear();
                tbTenPhuCap.Clear();
                tbSoTien.Clear();
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

                if (tbMaPhuCap.ReadOnly == true)
                {
                    //Sửa
                    PhuCap edit = dbContext.PhuCaps.Find(tbMaPhuCap.Text);
                    if (edit == null)
                    {
                        MessageBox.Show("Phụ cấp không tồn tại");
                    }
                    else
                    {
                        edit.TenPhuCap = tbTenPhuCap.Text;
                        edit.MucPhuCap = float.Parse(tbSoTien.Text);
                        dbContext.Entry<PhuCap>(edit).State = System.Data.Entity.EntityState.Modified;
                        dbContext.SaveChanges();
                        MessageBox.Show("Lưu thông tin thành công");

                    }
                }
                else
                {
                    //Thêm
                    PhuCap checkExit = dbContext.PhuCaps.Find(tbMaPhuCap.Text);
                    if (checkExit != null)
                    {
                        MessageBox.Show("Mã phụ cấp đã tồn tại");
                    }
                    else
                    {

                        PhuCap phucap = new PhuCap();
                        phucap.MaPhuCap = tbMaPhuCap.Text;
                        phucap.TenPhuCap = tbTenPhuCap.Text;
                        phucap.MucPhuCap = float.Parse(tbSoTien.Text);
                        dbContext.PhuCaps.Add(phucap);
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

            string maphucap = scTimIDPhuCap.Text;
            string tenphucap = scTimTenPhuCap.Text;
            var list = GetData().Where(s => s.MaPhuCap.StartsWith(maphucap) && s.TenPhuCap.StartsWith(tenphucap)).ToList();

            dgv.DataSource = null;
            dgv.DataSource = list;
        }

        private void scTimIDPhuCap_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void scTimTenPhuCap_TextChanged(object sender, EventArgs e)
        {
            search();
        }

       

        
    }
}