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
    public partial class FrmOrder : Form
    {
        public FrmOrder()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-07T8MF2\\MSSQLSERVER01;Initial Catalog=DbistanbulAkademi;Integrated Security=True");

        void OrderList()
        {
            SqlCommand command = new SqlCommand("Execute OrderList", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void FrmOrder_Load(object sender, EventArgs e)
        {
            OrderList();

            //Müşteri Bilgisi
            SqlCommand command1 = new SqlCommand("Select CustomerID,CustomerName + ' ' + CustomerSurname As CustomerNameSurname From TblCustomer", connection);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable dataTable1 = new DataTable();
            adapter1.Fill(dataTable1);
            cmbCustomer.DisplayMember = "CustomerNameSurname";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.DataSource = dataTable1;


            //Ürün Bilgisi
            SqlCommand command2 = new SqlCommand("Select ProductID,ProductName From TblProduct", connection);
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable dataTable2 = new DataTable();
            adapter2.Fill(dataTable2);
            cmbProduct.DisplayMember = "ProductName";
            cmbProduct.ValueMember = "ProductID";
            cmbProduct.DataSource = dataTable2;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Fluent Validation --> Entity Framework
            //Business Layer
            //Single Responsibility --> 

            connection.Open();
            SqlCommand command = new SqlCommand("insert into TblOrder (CustomerID,ProductID,OrderPrice) Values (@p1,@p2,@p3)", connection);
            command.Parameters.AddWithValue("@p1", cmbCustomer.SelectedValue);
            command.Parameters.AddWithValue("@p2", cmbProduct.SelectedValue);
            command.Parameters.AddWithValue("@p3", txtPrice.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Sipariş başarılı bir şekilde alındı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OrderList();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            OrderList();
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From TblProduct where ProductID=@p1", connection);
            command.Parameters.AddWithValue("@p1", cmbProduct.SelectedValue.ToString());
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                txtPrice.Text = dataReader["SalePrice"].ToString();
            }
            connection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtOrderID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
           //cmbCustomer.SelectedValue = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtDate.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }
    }
}



/*
 Select OrderID,ProductName,CustomerName + ' ' + CustomerSurname As Müşteri,OrderPrice,OrderDate From TblOrder Inner Join TblCustomer On TblOrder.CustomerID=TblCustomer.CustomerID Inner Join TblProduct On TblOrder.ProductID=TblProduct.ProductID
 */