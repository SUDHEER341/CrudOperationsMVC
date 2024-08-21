using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebFormsDemo
{
    public partial class StudentInfo : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["AMDBConnectionString"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        DataTable dt;

        public void DataLoad()
        {
            if(Page.IsPostBack)
            {
                gridview1.DataBind();
            }
        }

        public void ClearAllData()
        {
            txtname.Text = txtemail.Text = lblmessage.Text = "";
            txtdob.Text = DateTime.Today.Date.ToString();
            ddlgender.SelectedValue = ddlgender.Items[0].ToString();
            chkboxagree.Checked = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblsid.Text = gridview1.SelectedRow.Cells[1].Text;
            txtname.Text = gridview1.SelectedRow.Cells[2].Text;          
            txtemail.Text = gridview1.SelectedRow.Cells[3].Text; 
            ddlgender.Text = gridview1.SelectedRow.Cells[4].Text;
            txtdob.Text = gridview1.SelectedRow.Cells[5].Text;

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            if(txtname.Text!= "" && txtemail.Text!= "" && chkboxagree.Checked)
            {
                using(con = new SqlConnection(cs))
                {
                    con.Open();
                    cmd = new SqlCommand("insert into Student values('"+txtname.Text+"','"+txtemail.Text+"','"+ddlgender.Text+"','"+txtdob.Text+"')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DataLoad();
                    ClearAllData();
                    lblmessage.Text = "Student added successfully";
                }
            }
            else
            {
                lblmessage.Text = "Fill all columns";
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            ClearAllData();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
          

            using(con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand("DeleteStudent", con);
                cmd.CommandType= CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudentId", lblsid.Text);
                cmd.ExecuteNonQuery ();
                con.Close();
                DataLoad();
                ClearAllData();
                lblmessage.Text = "data deleted succesfully";
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            

            using (con = new SqlConnection(cs))
            {
                con.Open();
                cmd = new SqlCommand("UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // add parameters
                cmd.Parameters.AddWithValue("@StudentID", lblsid.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                cmd.Parameters.AddWithValue("@Gender", ddlgender.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", txtdob.Text);

                cmd.ExecuteNonQuery();

                con.Close();
                DataLoad();
                ClearAllData();

                lblmessage.Text = "Student updated successfully";
            }

        }
    }
}