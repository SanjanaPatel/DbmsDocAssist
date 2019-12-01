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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            this.ActiveControl = tbcat;
            tbcat.Focus();
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
        private void CreateWordDocument(object filename, object SaveAs, String usnpass, String tdate)
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
                MySqlConnection con = new MySqlConnection("server = localhost; user id = root;  password = redhat; persistsecurityinfo = True; database = dbproject");

                con.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from student where usn='" + usnpass + "'", con);
                MySqlDataReader rdusn = cmd.ExecuteReader();
                String tbname, tbsem, tbbranch;
                if (rdusn.Read())
                {
                    tbname = (rdusn["name"].ToString());
                    tbsem = (rdusn["semester"].ToString());
                    tbbranch = (rdusn["branch"].ToString());
                }
                else
                {
                    MessageBox.Show("Incorrect USN, corresponding student record not found!");
                    tbname = "";
                    tbsem = "";
                    tbbranch = "";
                }
                con.Close();
                //find and replace
                String sem = tbsem;
                String ext;
                if (sem == "1")
                {
                    ext = "st";
                }
                else if (sem == "2")
                {
                    ext = "nd";
                }
                else if (sem == "3")
                {
                    ext = "rd";
                }
                else
                {
                    ext = "th";
                }
                this.FindAndReplace(wordApp, "<name>", tbname.ToString());
                this.FindAndReplace(wordApp, "<semester>", tbsem + ext + " Semester");
                this.FindAndReplace(wordApp, "<branch>", tbbranch);
                this.FindAndReplace(wordApp, "<event>", tbcat.Text + " tournament");
                this.FindAndReplace(wordApp, "<date>", tdate.ToString());
                this.FindAndReplace(wordApp, "<acadyear>", DateTime.Now.Year + "-" + Convert.ToString(DateTime.Now.Year + 1));
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

            String pathdir = "G:\\vstudio\\dbms1\\dbms1\\" + tbfold.Text+"\\";
            System.IO.Directory.CreateDirectory(pathdir);

            MySqlConnection con = new MySqlConnection("server = localhost; user id = root;  password = redhat; persistsecurityinfo = True; database = events");

            con.Open();

            MySqlCommand cmd = new MySqlCommand("Select * from sports2019 where category='" + tbcat.Text + "'", con);

            String usn, tdate;
            MySqlDataReader rdusn = cmd.ExecuteReader();
            while (rdusn.Read())
            {

                usn = (rdusn["usn"].ToString());
                tdate = (rdusn["conductedon"].ToString());
                CreateWordDocument(@"G:\vstudio\dbms1\dbms1\sportscertif2.docx", @pathdir + usn+".docx", usn, tdate);
            }
            this.Close();
        }
    }
}
