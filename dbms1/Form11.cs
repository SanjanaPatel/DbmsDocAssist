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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String passwd;
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root;  password = redhat; persistsecurityinfo = True; database = dbproject");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from login where uname='" + tbuname.Text + "'", con);
            MySqlDataReader rdusn = cmd.ExecuteReader();
            if (rdusn.Read())
            {
                passwd = Convert.ToString(tbpass.Text);
                String epasswd = (rdusn["passwd"].ToString());
                int per = Convert.ToInt16((rdusn["per"].ToString()));
                String usn = (rdusn["uname"].ToString());
                if (passwd == epasswd)
                {
                    if (per == 1)
                    {
                        Form13 f1 = new Form13(usn);
                        f1.Show();
                    }
                    else if (per == 2)
                    {
                        Form12 f2 = new Form12(usn);
                        f2.Show();
                    }
                    else
                    {
                        Form14 f3 = new Form14(usn);
                        f3.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect login or password");
                }
            }
            else
            {
                MessageBox.Show("Incorrect login or password");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
