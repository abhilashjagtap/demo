using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
                con.Open();
                SqlCommand scmd;
                SqlDataReader dat;
                string outpt = " ";

                string sq = "select * from employee";

                scmd = new SqlCommand(sq, con);

                dat = scmd.ExecuteReader();

                while (dat.Read())
                {
                    outpt = outpt + dat.GetValue(1) + "-" + dat.GetValue(2) + "-" + dat.GetValue(3) + "</br>";
                }
                Response.Write(outpt);
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
                con.Open();

                string insertQuery = "insert into employee(Ename,Emob,Dept)values (@ename,@emob,@dept)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@ename", TextBox1.Text);
                cmd.Parameters.AddWithValue("@emob", TextBox2.Text);
                cmd.Parameters.AddWithValue("@dept", TextBox3.Text);

                cmd.ExecuteNonQuery();

                Response.Write("Student inseted Successfully!!!thank you");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";

                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
                con.Open();
                String del = "delete  from employee where Ename= '" + TextBox1.Text +"'";
                SqlCommand cmd = new SqlCommand(del, con);
                cmd.ExecuteNonQuery();

                Response.Write("Deleted.");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";

            }
            catch(Exception ex)
            { 
                Response.Write(ex.Message);
            }
            }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
                con.Open();
                String up = "update employee set Dept= '" + TextBox3.Text + "'where Ename='" + TextBox1.Text +"'";
                SqlCommand cmd = new SqlCommand(up, con);
                cmd.ExecuteNonQuery();

                Response.Write("updated.");
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
    }
}

