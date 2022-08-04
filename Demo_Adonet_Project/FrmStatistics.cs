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

namespace Demo_Adonet_Project
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-07T8MF2\\MSSQLSERVER01;Initial Catalog=DbistanbulAkademi;Integrated Security=True");
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command1 = new SqlCommand("Select count(*) From TblCustomer", connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                lblCustomerCount.Text = reader1[0].ToString();
            }
            connection.Close();

            connection.Open();
            SqlCommand command2 = new SqlCommand("Select count(*) as Sayi From TblProduct", connection);
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                lblProductCount.Text = reader2["Sayi"].ToString();
            }
            connection.Close();

            connection.Open();
            SqlCommand command3 = new SqlCommand("Select ProductName From TblProduct Where ProductStock=(Select Max(ProductStock) From TblProduct)", connection);
            SqlDataReader reader3 = command3.ExecuteReader();
            while (reader3.Read())
            {
                lblMaxStock.Text = reader3[0].ToString();
            }
            connection.Close();

            connection.Open();
            SqlCommand command4 = new SqlCommand("Select * From TblCustomer Where CustomerID=3", connection);
            SqlDataReader reader4 = command4.ExecuteReader();
            while (reader4.Read())
            {
                lblCustomer.Text = reader4["CustomerName"].ToString() + " " + reader4["CustomerSurname"].ToString();
            }
            connection.Close();

            //Timer Kodu
            timer1.Start();
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //sayac++;
            //lblTime.Text = sayac.ToString();
            //if (sayac == 50)
            //{
            //    timer1.Stop();
            //}

            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToShortDateString();
        }
    }
}
