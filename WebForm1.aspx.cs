using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebAppTesting
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Customer_DB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[customer_info]
           ([FirstName]
           ,[LastName]
           ,[Department])
     VALUES
           ('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtDepartment.Text + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Write("Data insreted successfully");
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Customer_DB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[customer_info]
   SET[FirstName] = '" + txtFirstName.Text + "' ,[LastName] = '" + txtLastName.Text + "' ,[Department] = '" + txtDepartment.Text + "' WHERE [FirstName] = '" + txtFirstName.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Write("Data updated successfully");
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Customer_DB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand(@"DELETE FROM[dbo].[customer_info]
      WHERE [FirstName]='" + txtFirstName.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Write("Data Deleted successfully");
            con.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost\\sqlexpress;Initial Catalog=Customer_DB;Integrated Security=True");
            SqlDataAdapter sqlda = new SqlDataAdapter("select *from customer_info", con);
            con.Open();
            DataTable db1 = new DataTable();
            sqlda.Fill(db1);
            CustomerInfo.DataSource = db1;
            CustomerInfo.DataBind();
            con.Close();
        }
    }
    }
