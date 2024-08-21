using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WinFormsAppDemo
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-4FCMKC7;Initial Catalog=AMDB;User ID=sa;Password=12345");
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into Employee_WF values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", con);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Data successfully inserted");
            con.Close();


        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Employee_WF set Name ='" + textBox2.Text + "', Address= '" + textBox3.Text + "',Salary ='" + textBox4.Text + "' where Employee_Id= '" + textBox1.Text + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data updated successfully");
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delte Employee_WF where Employee_Id='" + textBox1.Text + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Deleted data Successfully");
            con.Close();
        }
    }
}
