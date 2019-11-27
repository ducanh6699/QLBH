﻿using System;
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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            layChucNang();
        }

        private void layChucNang()
        {
            String sql = "select * from ChucNang";
            DataTable dt = ThuvienWin.XemQuery(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Button btn = new Button();
                btn.Tag = dt.Rows[i]["TenChucNang"].ToString();
                btn.Text = dt.Rows[i]["MoTa"].ToString();
                btn.Height = 100;
                btn.Width = 150;
                btn.Click += btnflp_Click;
                btn.Enabled = (ThuvienWin.ChucNangCuaNguoiDung.IndexOf(dt.Rows[i]["TenChucNang"].ToString()) > -1);
                flpbutton.Controls.Add(btn);
            }
        }

        private void btnflp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "Mặt hàng":
                    mathang mathang = new mathang();
                    mathang.ShowDialog();
                    break;

                case "Thoát chương trình":
                    ThuvienWin.Thoat();
                    break;

                case "Bán hàng":
                    banhang banhang = new banhang();
                    banhang.ShowDialog();
                    break;

                //case "Danh sách hóa đơn":
                //    DSHoaDon DSHoaDon = new DSHoaDon();
                //    DSHoaDon.ShowDialog();
                //    break;

                default:
                    MessageBox.Show("Chức năng này đang phát triển", "Thông báo");
                    break;
            }
        }
    }
}
