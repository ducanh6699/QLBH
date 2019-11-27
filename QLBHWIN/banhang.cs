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
    public partial class banhang : Form
    {
        public banhang()
        {
            InitializeComponent();
        }

        String MaHD, MaSuaMH_HD, MaMH_HD, MaChonHD;

        private void TaoMaHoaDon()
        {
            String sql = "SELECT Top 1 * FROM hoadon ORDER BY hoadon.ID DESC";
            DataTable tb = new DataTable();
            tb = ThuvienWin.XemQuery(sql);
            if (tb.Rows.Count > 0)
                MaHD = (int.Parse(tb.Rows[0]["Id"].ToString()) + 1).ToString();
            else
                MaHD = "1";
        }

        private void TaoMaHD_MH()
        {
            String sql = "SELECT Top 1 * FROM mathang_hoadon ORDER BY mathang_hoadon.ID DESC";
            DataTable tb = new DataTable();
            tb = ThuvienWin.XemQuery(sql);
            if (tb.Rows.Count > 0)
                MaMH_HD = (int.Parse(tb.Rows[0]["Id"].ToString()) + 1).ToString();
            else
                MaMH_HD = "1";
        }

        private void LayHoaDon()
        {
            String sql = @"SELECT * from hoadon";
            DataTable dt = new DataTable();
            dt = ThuvienWin.XemQuery(sql);

            dgvHoaDon.DataSource = dt;
        }

        private void LayMatHang()
        {
            String sql = "select * from mathang";
            DataTable tb = new DataTable();
            tb = ThuvienWin.XemQuery(sql);

            cbThemMH.DataSource = tb;
            cbThemMH.DisplayMember = "Tenhang";
            cbThemMH.ValueMember = "ID";
            cbThemMH.SelectedIndexChanged += cbThemMH_SelectedIndexChanged;

            sql = "select * from mathang";
            DataTable dt = new DataTable();
            dt = ThuvienWin.XemQuery(sql);
            cbSuaMH.DataSource = dt;
            cbSuaMH.DisplayMember = "Tenhang";
            cbSuaMH.ValueMember = "ID";
            cbSuaMH.SelectedIndexChanged += cbSuaMH_SelectedIndexChanged;
        }

        private void cbSuaMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = ThuvienWin.XemQuery(String.Format("select * from mathang where ID = {0}", cbSuaMH.SelectedValue.ToString()));
            txtSuaMV.Text = dt.Rows[0]["Mavach"].ToString();
            txtSuaDG.Text = dt.Rows[0]["Gia"].ToString();
            txtSuaCL.Text = dt.Rows[0]["Conlai"].ToString();
        }

        private void cbThemMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = ThuvienWin.XemQuery(String.Format("select * from mathang where ID = {0}", cbThemMH.SelectedValue.ToString()));
            txtThemMV.Text = dt.Rows[0]["Mavach"].ToString();
            txtThemDG.Text = dt.Rows[0]["Gia"].ToString();
            txtThemCL.Text = dt.Rows[0]["Conlai"].ToString();
        }

        private void btnTaoHD_Click(object sender, EventArgs e)
        {
            String sql = String.Format("insert into hoadon (ID,Tongtien,Ngaytao) values({0},'0','{1}')", MaHD, DateTime.Today.ToString());
            ThuvienWin.ThemSuaXoaQuery(sql);
            MessageBox.Show("Đã thêm thành công!", "Thông báo");
            LayHoaDon();
            TaoMaHoaDon();
        }

        private void banhang_Load(object sender, EventArgs e)
        {
            LayHoaDon();
            LayMatHang();
            TaoMaHoaDon();
            TaoMaHD_MH();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1) // bấm nút xóa trên dgv
            {
                if (ThuvienWin.confirm())
                {
                    ThuvienWin.ThemSuaXoaQuery("delete from hoadon where ID = " + dgvHoaDon.Rows[e.RowIndex].Cells[2].Value.ToString());
                    MessageBox.Show("Đã xóa thành công!", "Thông báo");
                    dgvMatHang_HoaDon.DataSource = ThuvienWin.XemQuery(String.Format(@"SELECT mathang_hoadon.ID, mathang_hoadon.Mamathang, mathang_hoadon.Mahoadon, mathang_hoadon.Soluongmathang, mathang.Mavach, mathang.Tenhang, mathang.Gia, mathang_hoadon.Thanhtien
                                            FROM mathang INNER JOIN mathang_hoadon ON mathang.ID = mathang_hoadon.Mamathang
                                            WHERE (((mathang_hoadon.Mahoadon)={0}));", dgvHoaDon.Rows[e.RowIndex].Cells[2].Value.ToString()));
                    LayHoaDon();
                    TaoMaHoaDon();
                }
            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1) // bấm nút hiển thị trên dgv
            {
                MaChonHD = dgvHoaDon.Rows[e.RowIndex].Cells[2].Value.ToString();
                dgvMatHang_HoaDon.DataSource = ThuvienWin.XemQuery(String.Format(@"SELECT mathang_hoadon.ID, mathang_hoadon.Mamathang, mathang_hoadon.Mahoadon, mathang_hoadon.Soluongmathang, mathang.Mavach, mathang.Tenhang, mathang.Gia, mathang_hoadon.Thanhtien
                                            FROM mathang INNER JOIN mathang_hoadon ON mathang.ID = mathang_hoadon.Mamathang
                                            WHERE (((mathang_hoadon.Mahoadon)={0}));", MaChonHD));
            }
        }

        private void dgvMatHang_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1) // bấm nút xóa trên dgv
            {
                if (ThuvienWin.confirm())
                {
                    DataTable dt = ThuvienWin.XemQuery("select * from hoadon where ID = " + MaChonHD);
                    ThuvienWin.ThemSuaXoaQuery(String.Format("update hoadon set Tongtien = '{0}' where ID = {1}", int.Parse(dt.Rows[0]["Tongtien"].ToString()) - int.Parse(dgvMatHang_HoaDon.Rows[e.RowIndex].Cells[9].Value.ToString()), MaChonHD));
                    dt = ThuvienWin.XemQuery("select * from mathang where ID = " + dgvMatHang_HoaDon.Rows[e.RowIndex].Cells[3].Value.ToString());
                    ThuvienWin.ThemSuaXoaQuery(String.Format("update mathang set Conlai = '{0}' where ID = {1}", int.Parse(dt.Rows[0]["Conlai"].ToString()) + int.Parse(dgvMatHang_HoaDon.Rows[e.RowIndex].Cells[5].Value.ToString()), dgvMatHang_HoaDon.Rows[e.RowIndex].Cells[3].Value.ToString()));
                    ThuvienWin.ThemSuaXoaQuery("delete from mathang_hoadon where ID = " + dgvMatHang_HoaDon.Rows[e.RowIndex].Cells[2].Value.ToString());
                    MessageBox.Show("Đã xóa thành công!", "Thông báo");
                    dgvMatHang_HoaDon.DataSource = ThuvienWin.XemQuery(String.Format(@"SELECT mathang_hoadon.ID, mathang_hoadon.Mamathang, mathang_hoadon.Mahoadon, mathang_hoadon.Soluongmathang, mathang.Mavach, mathang.Tenhang, mathang.Gia, mathang_hoadon.Thanhtien
                                            FROM mathang INNER JOIN mathang_hoadon ON mathang.ID = mathang_hoadon.Mamathang
                                            WHERE (((mathang_hoadon.Mahoadon)={0}));", MaChonHD));
                    cbThemMH_SelectedIndexChanged(sender, e);
                    cbSuaMH_SelectedIndexChanged(sender, e);
                    LayHoaDon();
                    TaoMaHD_MH();
                    tabControl1.SelectedTab = tabPage1;
                }
            }
            else if (e.ColumnIndex == 1 && e.RowIndex != -1) // bấm nút sửa trên dgv
            {
                MaSuaMH_HD = dgvMatHang_HoaDon.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbSuaMH.SelectedValue = dgvMatHang_HoaDon.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbSuaMH_SelectedIndexChanged(sender, e);
                txtSuaSL.Text = dgvMatHang_HoaDon.Rows[e.RowIndex].Cells[5].Value.ToString();
//                dgvMatHang_HoaDon.DataSource = ThuvienWin.XemQuery(String.Format(@"SELECT mathang_hoadon.ID, mathang_hoadon.Mamathang, mathang_hoadon.Mahoadon, mathang_hoadon.soluongmathang, mathang.mavach, mathang.tenmathang, mathang.dongia
//                                            FROM mathang INNER JOIN mathang_hoadon ON mathang.ID = mathang_hoadon.Mamathang
//                                            WHERE (((mathang_hoadon.Mahoadon)={0}));", MaChonHD));
                tabControl1.SelectedTab = tabPage2;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtThemSL.Text) > int.Parse(txtThemCL.Text))
            {
                MessageBox.Show("Không được mua quá số lượng hàng còn lại!", "Thông báo");
                return;
            }
            DataTable dt = ThuvienWin.XemQuery("select * from hoadon where ID = " + MaChonHD);
            int tongtien = int.Parse(dt.Rows[0]["Tongtien"].ToString()) + int.Parse(txtThemSL.Text) * int.Parse(txtThemDG.Text);
            ThuvienWin.ThemSuaXoaQuery(String.Format("insert into mathang_hoadon(ID,Mamathang,Mahoadon,Soluongmathang,Thanhtien) values({0},{1},{2},'{3}','{4}')", MaMH_HD, cbThemMH.SelectedValue.ToString(), MaChonHD, txtThemSL.Text, int.Parse(txtThemDG.Text) * int.Parse(txtThemSL.Text)));
            ThuvienWin.ThemSuaXoaQuery(String.Format("update hoadon set Tongtien = '{0}' where ID = {1}", tongtien, MaChonHD));
            dt = ThuvienWin.XemQuery("select * from mathang where ID = " + cbThemMH.SelectedValue.ToString());
            ThuvienWin.ThemSuaXoaQuery(String.Format("update mathang set Conlai = '{0}' where ID = {1}", int.Parse(dt.Rows[0]["Conlai"].ToString()) - int.Parse(txtThemSL.Text), cbThemMH.SelectedValue.ToString()));
            MessageBox.Show("Đã thêm thành công!", "Thông báo");
            dgvMatHang_HoaDon.DataSource = ThuvienWin.XemQuery(String.Format(@"SELECT mathang_hoadon.ID, mathang_hoadon.Mamathang, mathang_hoadon.Mahoadon, mathang_hoadon.Soluongmathang, mathang.Mavach, mathang.Tenhang, mathang.Gia, mathang_hoadon.Thanhtien
                                            FROM mathang INNER JOIN mathang_hoadon ON mathang.ID = mathang_hoadon.Mamathang
                                            WHERE (((mathang_hoadon.Mahoadon)={0}));", MaChonHD));
            txtThemSL.Text = "";
            cbThemMH_SelectedIndexChanged(sender, e);
            LayHoaDon();
            TaoMaHD_MH();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtSuaSL.Text) > int.Parse(txtSuaCL.Text))
            {
                MessageBox.Show("Không được mua quá số lượng hàng còn lại!", "Thông báo");
                return;
            }
            DataTable dt1 = ThuvienWin.XemQuery("select * from hoadon where ID = " + MaChonHD);
            DataTable dt2 = ThuvienWin.XemQuery("select * from mathang_hoadon where ID = " + MaSuaMH_HD);
            int SLold = int.Parse(dt2.Rows[0]["Soluongmathang"].ToString());
            int SLnew = int.Parse(txtSuaSL.Text);
            int tongtien = int.Parse(dt1.Rows[0]["Tongtien"].ToString());
            if (SLnew > SLold)
            {
                tongtien = tongtien + ((SLnew - SLold) * int.Parse(txtSuaDG.Text));
                DataTable dt = ThuvienWin.XemQuery("select * from mathang where ID = " + cbSuaMH.SelectedValue.ToString());
                ThuvienWin.ThemSuaXoaQuery(String.Format("update mathang set Conlai = '{0}' where ID = {1}", int.Parse(dt.Rows[0]["Conlai"].ToString()) - (SLnew - SLold), cbSuaMH.SelectedValue.ToString()));
            }
            else
            {
                tongtien = tongtien - ((SLold - SLnew) * int.Parse(txtSuaDG.Text));
                DataTable dt = ThuvienWin.XemQuery("select * from mathang where ID = " + cbSuaMH.SelectedValue.ToString());
                ThuvienWin.ThemSuaXoaQuery(String.Format("update mathang set Conlai = '{0}' where ID = {1}", int.Parse(dt.Rows[0]["Conlai"].ToString()) + (SLold - SLnew), cbSuaMH.SelectedValue.ToString()));
            }
            ThuvienWin.ThemSuaXoaQuery(String.Format("update hoadon set Tongtien = '{0}' where ID = {1}", tongtien.ToString(), MaChonHD));
            ThuvienWin.ThemSuaXoaQuery(String.Format("update mathang_hoadon set Soluongmathang = '{0}', Thanhtien = '{1}' where ID = {2}", SLnew, SLnew * int.Parse(txtSuaDG.Text), MaSuaMH_HD));
            MessageBox.Show("Sửa thành công!", "Thông Báo"); dgvMatHang_HoaDon.DataSource = ThuvienWin.XemQuery(String.Format(@"SELECT mathang_hoadon.ID, mathang_hoadon.Mamathang, mathang_hoadon.Mahoadon, mathang_hoadon.Soluongmathang, mathang.Mavach, mathang.Tenhang, mathang.Gia, mathang_hoadon.Thanhtien
                                            FROM mathang INNER JOIN mathang_hoadon ON mathang.ID = mathang_hoadon.Mamathang
                                            WHERE (((mathang_hoadon.Mahoadon)={0}));", MaChonHD));
            txtSuaSL.Text = "";
            cbSuaMH_SelectedIndexChanged(sender, e);
            LayHoaDon();
        }
    }
}
