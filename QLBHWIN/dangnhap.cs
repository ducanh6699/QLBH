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
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            String sql = String.Format("select * from taikhoan where tendangnhap = '{0}' and matkhau = '{1}'", txtTaiKhoan.Text, txtMatKhau.Text);
            DataTable tb = new DataTable();
            tb = ThuvienWin.XemQuery(sql);

            if (tb.Rows.Count == 0)
            {
                MessageBox.Show("Tài Khoản hoặc Mật Khẩu sai", "Thông Báo");
                return;
            }
            ThuvienWin.MaNguoiDung = int.Parse(tb.Rows[0]["ID"].ToString());
            ThuvienWin.Quyen = int.Parse(tb.Rows[0]["Maquyen"].ToString());
            sql = String.Format(@"SELECT chucnang.tenchucnang, chucnang.mota
                                        FROM chucnang INNER JOIN quyen_chucnang ON chucnang.ID = quyen_chucnang.Machucnang
                                        WHERE (((quyen_chucnang.Maquyen)={0}));", tb.Rows[0]["Maquyen"].ToString());
            tb = ThuvienWin.XemQuery(sql);
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                ThuvienWin.ChucNangCuaNguoiDung += tb.Rows[i]["TenChucNang"].ToString();
            }
            this.Hide();
            Menu Menu = new Menu();
            Menu.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            ThuvienWin.Thoat();
        }
    }
}
