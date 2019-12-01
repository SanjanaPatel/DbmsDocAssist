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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root;  password = redhat; persistsecurityinfo = True; database = dbproject");
            con.Open();
            String entryquery1 = "INSERT INTO student(usn,name,branch,semester,dob,email,phone,city,state,zip) values(@usn,@name,@branch,@semester,@dob,@email,@phone,@city,@state,@zip)";
            MySqlCommand cmd = new MySqlCommand(entryquery1, con);
            //MySqlDataAdapter entry1 = new MySqlDataAdapter(entryquery1, con);
            //entry1.SelectCommand.ExecuteNonQuery();
            cmd.Parameters.Add("@usn", MySqlDbType.VarChar).Value = tbusn.Text;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = tbname.Text;
            cmd.Parameters.Add("@branch", MySqlDbType.VarChar).Value = tbranch.Text;
            cmd.Parameters.Add("@semester", MySqlDbType.Int16).Value = sem.Text;
           // cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = tbaddr.Text;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = tbphone.Text;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = tbemail.Text;
            cmd.Parameters.Add("@zip", MySqlDbType.VarChar).Value = tbzip.Text;
            cmd.Parameters.Add("@city", MySqlDbType.VarChar).Value = tbcity.Text;
            cmd.Parameters.Add("@state", MySqlDbType.VarChar).Value = tbstate.Text;
            cmd.Parameters.Add("@dob", MySqlDbType.Date).Value = dob.Value.Date;
            int i = cmd.ExecuteNonQuery();
            if (i >= 1)
            {
                MessageBox.Show("Successfully entered data!");
            }
            else
            {
                MessageBox.Show("Data not entered");
            }
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
