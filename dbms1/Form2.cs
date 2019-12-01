using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbms1
{
    public partial class Form2 : Form
    {
        Form1 f1 = null;

        public Form2(string str1, Form1 f1)
        {
            InitializeComponent();
            tb3.Text = str1;
            this.f1 = f1;
        }

        private void b3_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f1.Show();
            this.Close();
        }
    }
}
