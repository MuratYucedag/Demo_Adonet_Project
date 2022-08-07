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
    public partial class FrmCustomer : Form
    {
        public FrmCustomer()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-07T8MF2\\MSSQLSERVER01;Initial Catalog=DbistanbulAkademi;Integrated Security=True");
        private void btnList_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From TblCustomer", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into TblCustomer (CustomerName,CustomerSurname,CustomerBalance,CustomerCity) values (@p1,@p2,@p3,@p4)", connection);
            command.Parameters.AddWithValue("@p1", txtCustomerName.Text);
            command.Parameters.AddWithValue("@p2", txtCustomerSurname.Text);
            command.Parameters.AddWithValue("@p3", txtBalance.Text);
            command.Parameters.AddWithValue("@p4", comboBox1.SelectedValue);
            command.ExecuteNonQuery();
            MessageBox.Show("Müşteri sisteme kaydedildi");
            connection.Close();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From TblCity", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            comboBox1.ValueMember = "CityID";
            comboBox1.DisplayMember = "CityName";
            comboBox1.DataSource = dataTable;
            connection.Close();
        }
    }
}
