using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace QLBHWEB
{
    public partial class index : System.Web.UI.Page
    {
        String conn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\QLBH.mdb";
        public void themsuaxoa(String sql)
        {
            OleDbConnection con = new OleDbConnection(conn);
            con.Open();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable dulieu(String sql)
        {
            OleDbConnection con = new OleDbConnection(conn);
            con.Open();
            OleDbDataAdapter ada = new OleDbDataAdapter(sql, con);
            DataTable tb = new DataTable();
            ada.Fill(tb);
            con.Close();
            return tb;
        }

        public void bindata()
        {
            DataTable tb = dulieu(String.Format("Select * from mathang"));
            mathang.DataSource = tb;
            mathang.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dangnhap"] == null)
            {
                dangnhap.Visible = true;
                banghang.Visible = false;
                navbarSupportedContent.Visible = false;
            }
            else
            {
                dangnhap.Visible = false;
                banghang.Visible = true;
                navbarSupportedContent.Visible = true;
                bindata();
            }
        }


        protected void login_Click(object sender, EventArgs e)
        {
            DataTable tb = dulieu(String.Format("Select * from taikhoan where Tendangnhap ='{0}' and Matkhau = '{1}'",taikhoan.Text, matkhau.Text));
            if (tb.Rows.Count < 1)
            {
                sai.Visible = true;
            }
            else
            {
                Session["dangnhap"] = taikhoan.Text;
                bindata();
                dangnhap.Visible = false;
                banghang.Visible = true;
                navbarSupportedContent.Visible = true;
            }
        }

        protected void mathang_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Sua")
            {

            }
            if (e.CommandName == "Xoa")
            {
                int _rowIndex = Convert.ToInt32(e.CommandArgument);
                String id = mathang.Rows[_rowIndex].Cells[2].Text;
            }
        }
    }
}