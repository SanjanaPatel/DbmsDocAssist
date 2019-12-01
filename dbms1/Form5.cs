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
    public partial class certif : Form
    {
        public certif()
        {
            InitializeComponent();
            this.ActiveControl = tbusn;
            tbusn.Focus();
        }

        private void FindAndReplace(Word.Application wordApp, object ToFindText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref ToFindText,
                ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundLike,
                ref nmatchAllforms, ref forward,
                ref wrap, ref format, ref replaceWithText,
                ref replace, ref matchKashida,
                ref matchDiactitics, ref matchAlefHamza,
                ref matchControl);
        }

        //Creeate the Doc Method
        private void CreateWordDocument(object filename, object SaveAs)
        {
            Word.Application wordApp = new Word.Application();
            object missing = Missing.Value;
            Word.Document myWordDoc = null;

            if (File.Exists((string)filename))
            {
                object readOnly = false;
                object isVisible = false;
                wordApp.Visible = false;

                myWordDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing);
                myWordDoc.Activate();

                //find and replace
                String sem = tbsem.Text;
                String ext;
                if (sem == "1")
                {
                    ext = "st";
                }
                else if(sem=="2")
                {
                    ext = "nd";
                }
                else if(sem == "3")
                {
                    ext = "rd";
                }
                else
                {
                    ext = "th";
                }
                this.FindAndReplace(wordApp, "<name>", tbname.Text);
                this.FindAndReplace(wordApp, "<semester>", tbsem.Text+ext+" Semester");
                this.FindAndReplace(wordApp, "<branch>", tbbranch.Text);
                this.FindAndReplace(wordApp, "<event>", tbevent.Text+" tournament");
                this.FindAndReplace(wordApp, "<date>", date.Value.Date);
                this.FindAndReplace(wordApp, "<acadyear>", DateTime.Now.Year + "-" + Convert.ToString(DateTime.Now.Year+1));
            }
            else
            {
                MessageBox.Show("File not Found!");
            }

            //Save as
            myWordDoc.SaveAs2(ref SaveAs, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing);

            myWordDoc.Close();
            wordApp.Quit();
            MessageBox.Show("File Created!");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlConnection con = new MySqlConnection("server = localhost; user id = root;  password = redhat; persistsecurityinfo = True; database = events");
            con.Open();
            String entryquery1 = "INSERT INTO sports2019(usn,category,conductedon) values(@usn,@category,@conductedon)";
            MySqlCommand cmd = new MySqlCommand(entryquery1, con);
            //MySqlDataAdapter entry1 = new MySqlDataAdapter(entryquery1, con);
            //entry1.SelectCommand.ExecuteNonQuery();
            cmd.Parameters.Add("@usn", MySqlDbType.VarChar).Value = tbusn.Text;
            cmd.Parameters.Add("@category", MySqlDbType.VarChar).Value = tbevent.Text;
            cmd.Parameters.Add("@conductedon", MySqlDbType.Date).Value = date.Value.Date;
            int i= cmd.ExecuteNonQuery();
            if (i>=1)
            {
                MessageBox.Show("Successfully entered data!");
            }
            else
            {
                MessageBox.Show("Data not entered");
            }
            con.Close();
            saveas1.ShowDialog();
            
            //CreateWordDocument(@"G:\vstudio\dbms1\dbms1\sportscertif1.docx", @"G:\vstudio\dbms1\dbms1\certificat.docx");
        }



        private void tbusn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                String usnval = tbusn.Text;
                MySqlConnection con = new MySqlConnection("server = localhost; user id = root;  password = redhat; persistsecurityinfo = True; database = dbproject");
                con.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from student where usn='" + tbusn.Text + "'", con);
                MySqlDataReader rdusn = cmd.ExecuteReader();
                if (rdusn.Read())
                {
                    tbname.Text = (rdusn["name"].ToString());
                    tbsem.Text = (rdusn["semester"].ToString());
                    tbbranch.Text = (rdusn["branch"].ToString());
                }
                else
                {
                    MessageBox.Show("Incorrect USN, corresponding student record not found!");
                    tbname.Text = "";
                    tbsem.Text = "";
                    tbbranch.Text = "";
                }
                con.Close();
            }
        }

        private void tbusn_Leave(object sender, EventArgs e)
        {
            String usnval = tbusn.Text;
            MySqlConnection con = new MySqlConnection("server = localhost; user id = root;  password = redhat; persistsecurityinfo = True; database = dbproject");
            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from student where usn='" + tbusn.Text + "'", con);
            MySqlDataReader rdusn = cmd.ExecuteReader();
            if (rdusn.Read())
            {
                tbname.Text = (rdusn["name"].ToString());
                tbsem.Text = (rdusn["semester"].ToString());
                tbbranch.Text = (rdusn["branch"].ToString());
            }
            else
            {
                MessageBox.Show("Incorrect USN, corresponding student record not found!");
                tbname.Text = "";
                tbsem.Text = "";
                tbbranch.Text = "";
            }
            con.Close();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            CreateWordDocument(@"G:\vstudio\dbms1\dbms1\sportscertif2.docx", saveas1.FileName);
        }
    }    
}
