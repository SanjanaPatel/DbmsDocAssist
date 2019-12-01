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
    public partial class Form17 : Form
    {
        String usne;
        public Form17(String usn)
        {
            InitializeComponent();
            usne = usn;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form9 f1 = new Form9();
            f1.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form6 f1 = new Form6(usne);
            f1.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form18 f1 = new Form18();
            f1.Show();
        }
    }
}
