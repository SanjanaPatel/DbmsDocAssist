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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
        }

        private void b1_Click(object sender, EventArgs e)
        {
            string stsum= Convert.ToString(Convert.ToInt32(tb1.Text) + Convert.ToInt32(tb2.Text));
            this.Hide();
            Form2 f2 = new Form2(stsum,this);
            f2.Show();
            
        }

        private void b2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
