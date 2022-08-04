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
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-07T8MF2\\MSSQLSERVER01;Initial Catalog=DbistanbulAkademi;Integrated Security=True");

        void ProductList()
        {
            SqlCommand command = new SqlCommand("Select * From TblProduct", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            ProductList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into TblProduct (ProductName,ProductStock,PurchasePrice,SalePrice,CategoryID,Status) values (@p1,@p2,@p3,@p4,@p5,@p6)", connection);
            command.Parameters.AddWithValue("@p1", txtProductName.Text);
            command.Parameters.AddWithValue("@p2", txtProductStock.Text);
            command.Parameters.AddWithValue("@p3", txtPurchasePrice.Text);
            command.Parameters.AddWithValue("@p4", txtSalePrice.Text);
            command.Parameters.AddWithValue("@p5", cmbCategory.SelectedValue);
            if (rdbActive.Checked == true)
            {
                command.Parameters.AddWithValue("@p6", "True");
            }
            if (rdbPassive.Checked == true)
            {
                command.Parameters.AddWithValue("@p6", "False");
            }
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün başarılı bir şekilde sisteme kaydedildi");
            connection.Close();
            ProductList();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From TblCategory", connection);
            SqlDataAdapter adapter=new SqlDataAdapter (command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryID";
            cmbCategory.DataSource = dataTable;
        }

        private void brnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Delete From TblProduct Where ProductId=@p1", connection);
            command.Parameters.AddWithValue("@p1", txtProductID.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün sistemden başarılı bir şekilde silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            connection.Close();
            ProductList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Update TblProduct Set ProductName=@p1,ProductStock=@p2,PurchasePrice=@p3,SalePrice=@p4,CategoryID=@p5,Status=@p6 where ProductId=@p7", connection);
            command.Parameters.AddWithValue("@p1", txtProductName.Text);
            command.Parameters.AddWithValue("@p2", txtProductStock.Text);
            command.Parameters.AddWithValue("@p3", txtPurchasePrice.Text);
            command.Parameters.AddWithValue("@p4", txtSalePrice.Text);
            command.Parameters.AddWithValue("@p5", cmbCategory.SelectedValue);
            if (rdbActive.Checked == true)
            {
                command.Parameters.AddWithValue("@p6", "True");
            }
            if (rdbPassive.Checked == true)
            {
                command.Parameters.AddWithValue("@p6", "False");
            }
            command.Parameters.AddWithValue("@p7", txtProductID.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün başarılı bir şekilde sistemde güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            connection.Close();
            ProductList();
        }

        private void btnSearchForProductName_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From TblProduct where ProductName=@p1", connection);
            command.Parameters.AddWithValue("@p1", txtProductName.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btnSearchForStockLess_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From TblProduct where ProductStock<@p1", connection);
            command.Parameters.AddWithValue("@p1", txtProductStock.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btnSearchForStockMore_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From TblProduct where ProductStock>@p1", connection);
            command.Parameters.AddWithValue("@p1", txtProductStock.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
