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
    public partial class Form12 : Form
    {
        String usne;
        public Form12(String usn)
        {
            InitializeComponent();
            usne = usn;
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root;  password = redhat; persistsecurityinfo = True; database = dbproject");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from student where usn='" + usn + "'", con);
            MySqlDataReader rdusn = cmd.ExecuteReader();
            if (rdusn.Read())
            {
                label3.Text = (rdusn["name"].ToString());
                label4.Text = (rdusn["usn"].ToString());
                label5.Text = (rdusn["phone"].ToString());
                label6.Text = (rdusn["branch"].ToString());
                label7.Text = (rdusn["semester"].ToString());
                label11.Text = (rdusn["email"].ToString());
                //Image image = Image.FromFile(@"\G:\vstudio\dbms1\dbms1\student_profile_pictures\" + usn);
                //this.picture.Image = image;
            }
            else
            {
                MessageBox.Show("Incorrect USN");
            }
            con.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form17 f1 = new Form17(usne);
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 f1 = new Form11();
            f1.Show();
            this.Close();
        }
    }
}
