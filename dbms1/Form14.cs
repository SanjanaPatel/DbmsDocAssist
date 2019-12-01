using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;

namespace dbms1
{
    public partial class Form14 : Form
    {
        public Form14(String usn)
        {
            InitializeComponent();
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root;  password = redhat; persistsecurityinfo = True; database = dbproject");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from teacher where faculty_id='" + usn + "'", con);
            MySqlDataReader rdusn = cmd.ExecuteReader();
            if (rdusn.Read())
            {
                label3.Text = (rdusn["faculty_id"].ToString());
                label4.Text = (rdusn["tname"].ToString());
                label2.Text = (rdusn["phone"].ToString());
                label8.Text = (rdusn["dept"].ToString());
                label9.Text = (rdusn["designation"].ToString());
                label10.Text = (rdusn["email"].ToString());
                con.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form16 f1 = new Form16();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form11 f1 = new Form11();
            f1.Show();
            this.Close();
        }
    }
}
