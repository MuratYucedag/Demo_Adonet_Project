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
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length <= 5)
            {
                label3.Text = "şifre zayıf";
                label3.ForeColor = Color.Red;
            }
            else if(textBox2.Text.Length>5 && textBox2.Text.Length <= 8)
            {
                label3.Text = "şifre orta";
                label3.ForeColor = Color.Orange;
            }
            else if (textBox2.Text.Length > 8)
            {
                label3.Text = "şifre kuvvetli";
                label3.ForeColor = Color.Green;
            }
        }
    }
}
