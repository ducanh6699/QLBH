using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBHWIN
{
    public partial class mathang : Form
    {
        public mathang()
        {
            InitializeComponent();
        }

        String MaMH, MaSuaMH;

        private void TaoMaMatHang()
        {
            String sql = "SELECT Top 1 * FROM mathang ORDER BY mathang.ID DESC";
            DataTable tb = new DataTable();
            tb = ThuvienWin.XemQuery(sql);
            if (tb.Rows.Count > 0)
                MaMH = (int.Parse(tb.Rows[0]["Id"].ToString()) + 1).ToString();
            else
                MaMH = "1";
        }

        private void LayMatHang()
        {
            String sql = "SELECT * FROM mathang";
            DataTable dt = new DataTable();
            dt = ThuvienWin.XemQuery(sql);

            dgvMatHang.DataSource = dt;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ThuvienWin.confirm())
            {
                String sql = String.Format("insert into mathang (ID,Mavach,Tenhang,Gia,Conlai) values({0},'{1}','{2}',{3},'{4}')", MaMH, txtThemMV.Text, txtThemTMH.Text, txtThemGMH.Text, txtThemSL.Text);
                ThuvienWin.ThemSuaXoaQuery(sql);
                MessageBox.Show("Đã thêm thành công!", "Thông báo");
                TaoMaMatHang();
                LayMatHang();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ThuvienWin.confirm())
            {
                String sql = String.Format("update mathang set Mavach = '{0}', Tenhang = '{1}', Gia = {2}, Conlai = '{3}' where Id = {4}", txtSuaMV.Text, txtSuaTMH.Text, txtSuaGMH.Text, txtSuaSL.Text, MaSuaMH);
                ThuvienWin.ThemSuaXoaQuery(sql);
                MessageBox.Show("Sửa thành công!", "Thông Báo");
                LayMatHang();
            }
        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1 && e.RowIndex != -1) // bấm nút sửa trên dgv
            {
                MaSuaMH = dgvMatHang.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtSuaMV.Text = dgvMatHang.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtSuaTMH.Text = dgvMatHang.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtSuaGMH.Text = dgvMatHang.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtSuaSL.Text = dgvMatHang.Rows[e.RowIndex].Cells[5].Value.ToString();
                tabControl1.SelectedTab = tabPage2;
            }
            else if (e.ColumnIndex == 0 && e.RowIndex != -1) // bấm nút xóa trên dgv
            {
                if (ThuvienWin.confirm())
                {
                    String sql = String.Format("delete from mathang where ID = {0}", dgvMatHang.Rows[e.RowIndex].Cells[2].Value.ToString());
                    ThuvienWin.ThemSuaXoaQuery(sql);
                    MessageBox.Show("Xóa Thành Công!", "Thông Báo");
                    TaoMaMatHang();
                    LayMatHang();
                    tabControl1.SelectedTab = tabPage1;
                }
            }
        }

        private void mathang_Load(object sender, EventArgs e)
        {
            TaoMaMatHang();
            LayMatHang();
        }
    }
}
