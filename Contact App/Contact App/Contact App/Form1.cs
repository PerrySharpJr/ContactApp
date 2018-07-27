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

namespace Contact_App
{
    public partial class Form1 : Form
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\DiscGolf\DiscGolf\DB\ContactDB.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("contactAddOrEdit", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@mode", "Add");
                sqlCmd.Parameters.AddWithValue("@ContactsId", 0);
                sqlCmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@MobileNumber", txtMobileNumber.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error Message");
            }
            finally
            {
                sqlCon.Close();
            }
        }



    }
}
