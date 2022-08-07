using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_Adonet_Project
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-07T8MF2\\MSSQLSERVER01;Initial Catalog=DbistanbulAkademi;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From TblAdmin Where Username=@p1 and Password=@p2", connection);
            command.Parameters.AddWithValue("@p1", txtUsername.Text);
            command.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                FrmNavigation frm = new FrmNavigation();
                frm.userName = txtUsername.Text;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre");
            }
            connection.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
