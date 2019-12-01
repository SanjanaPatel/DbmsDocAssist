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
    public partial class Form15 : Form
    {
        String usne;
        public Form15(String usn)
        {
            InitializeComponent();
            usne = usn;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            certif f1 = new certif();
            f1.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form6 f1 = new Form6("");
            f1.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form9 f1 = new Form9();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form13 f1 = new Form13(usne);
            f1.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form18 f1 = new Form18();
            f1.Show();
        }
    }
}
