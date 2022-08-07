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
    public partial class FrmSearchByProduct : Form
    {
        public FrmSearchByProduct()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-07T8MF2\\MSSQLSERVER01;Initial Catalog=DbistanbulAkademi;Integrated Security=True");

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From TblProduct where ProductName Like '" + txtProductName.Text + "%'", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
