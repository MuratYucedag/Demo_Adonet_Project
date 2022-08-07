using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_Adonet_Project
{
    public partial class FrmNavigation : Form
    {
        public FrmNavigation()
        {
            InitializeComponent();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            FrmCustomer frm = new FrmCustomer();
            frm.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            FrmProduct frm = new FrmProduct();
            frm.Show();
        }

        private void btnCurrency_Click(object sender, EventArgs e)
        {
            FrmCurrency frm = new FrmCurrency();
            frm.Show();
        }

        //Access Modifier
        public string userName;
        private void FrmNavigation_Load(object sender, EventArgs e)
        {
            label1.Text = userName;
        }
    }
}
