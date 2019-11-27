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
    public partial class themsua : System.Web.UI.Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dangnhap"] == null)
            {
                Response.Redirect("index.aspx");
            }

            if (Request["id"] == null || Request["id"] == "")
            {
                them.Visible = true;
                sua.Visible = false;
            }
            else
            {
                try
                {
                    them.Visible = false;
                    sua.Visible = true;
                    DataTable tb = dulieu(String.Format("Select * from mathang where id = {0}", Request["id"]));
                    if (tb.Rows.Count == 0)
                    {
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        if (!IsPostBack)
                        {
                            mavach.Text = tb.Rows[0]["Mavach"].ToString();
                            tenhang.Text = tb.Rows[0]["Tenhang"].ToString();
                            soluong.Text = tb.Rows[0]["Conlai"].ToString();
                            gia.Text = tb.Rows[0]["Gia"].ToString();
                        }
                    }
                }
                catch
                {
                    Response.Redirect("index.aspx");
                }
            }
        }

        protected void them_Click(object sender, EventArgs e)
        {
            try
            {
                themsuaxoa(String.Format("Insert into mathang (Mavach,Tenhang,Conlai,Gia) values('{0}','{1}','{2}',{3})", mavach.Text, tenhang.Text, soluong.Text, gia.Text));
                Response.Write("<script>alert('Thêm thành công');</script>");
            }
            catch
            {
                Response.Write("<script>alert('Thêm thất bại');</script>");
            }
            
        }

        protected void sua_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format("Update mathang Set Mavach = '{0}' ,Tenhang = '{1}' ,Conlai = '{2}',Gia = {3} Where id = {4}", mavach.Text, tenhang.Text, soluong.Text, gia.Text, Request["id"]);
                themsuaxoa(sql);
                Response.Write("<script>alert('Sửa thành công');</script>");
            }
            catch
            {
                Response.Write("<script>alert('Sửa thất bại');</script>");
            }
        }
    }
}