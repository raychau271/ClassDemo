using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ELibaryManagement
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Test');</script>");
        }

        protected void Button1_Click(object sender, EventArgs e) //Login button click
        {
            string txtLogin = TextBox1.Text.Trim();
            string txtPass = TextBox2.Text.Trim();

            //if (validate())
            //{
            //    Response.Write("<script>alert('Invalid credentials');</script>");
            //}
            //else
            //{
            //    try
            //    {
            //        SqlConnection con = new SqlConnection(strcon);
            //        if (con.State == System.Data.ConnectionState.Closed)
            //        {
            //            con.Open();
            //        }


            //        SqlCommand cmd = new SqlCommand("SELECT * FROM admin_tbl WHERE username=@0 AND password=@1;", con);
            //        cmd.Parameters.AddWithValue("@0", txtLogin);
            //        cmd.Parameters.AddWithValue("@1", txtPass);
            //        //SqlCommand cmd = new SqlCommand("SELECT * FROM admin_tbl WHERE username='"+txtLogin+"' AND password='"+ txtPass+"';", con);
            //        SqlDataReader dr = cmd.ExecuteReader();

            //        if (dr.HasRows)
            //        {
            //            while (dr.Read())
            //            {
            //                Response.Write("<script>alert('Login Successful')</script>");
            //                Session["username"] = dr.GetValue(0).ToString();
            //                Session["full"] = dr.GetValue(2).ToString();
            //                Session["role"] = "admin";
            //            }
            //            Response.Redirect("homepage.aspx");
            //        }
            //        else
            //        {
            //            Response.Write("<script>alert('Invalid credentials');</script>");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write("<script>alert('" + ex.Message + "');</script>");
            //    }
            //}

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("SELECT * FROM admin_tbl WHERE username=@0 AND password=@1;", con);
                cmd.Parameters.AddWithValue("@0", txtLogin);
                cmd.Parameters.AddWithValue("@1", txtPass);
                //SqlCommand cmd = new SqlCommand("SELECT * FROM admin_tbl WHERE username='"+txtLogin+"' AND password='"+ txtPass+"';", con);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Login Successful')</script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["full"] = dr.GetValue(2).ToString();
                        Session["role"] = "admin";
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            //bool validate() //detect SQL injection
            //{
            //    HashSet<string> sqlkey = new HashSet<string>(); //Set contains possible harmful command

            //    sqlkey.Add(";");
            //    sqlkey.Add("'");
            //    sqlkey.Add("\"");
            //    sqlkey.Add("=");
            //    sqlkey.Add("drop");
            //    sqlkey.Add("select");
            //    sqlkey.Add("insert");
            //    sqlkey.Add("values");

            //    foreach (string item in sqlkey)
            //    {
            //        if (txtLogin.Contains(item) || txtPass.Contains(item))
            //        {
            //            return true;
            //        }
            //    }
            //    return false;
            //}
        }
    }
}