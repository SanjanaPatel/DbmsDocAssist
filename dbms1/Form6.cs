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
    public partial class Form6 : Form
    {
 
        public Form6(String usne)
        {
            InitializeComponent();
            if(usne=="")
            {

                this.ActiveControl = tbusn;
                tbusn.Focus();
            }
            else
            {
                tbusn.Text = usne;
                tbusn.Enabled=false;
                this.ActiveControl = tbsem;
                tbsem.Focus();
            }

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
                Word.Table gc = myWordDoc.Tables[1];
                MySqlConnection con = new MySqlConnection("server = localhost; user id = root;  password = redhat; persistsecurityinfo = True; database = dbproject");

                con.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from student where usn='" + tbusn.Text + "'", con);
                MySqlDataReader rdusn = cmd.ExecuteReader();
                if (rdusn.Read())
                {
                    String name = (rdusn["name"].ToString());
                    String sem = (rdusn["semester"].ToString());
                    String branch = (rdusn["branch"].ToString());

                    this.FindAndReplace(wordApp, "<name>", name);
                    this.FindAndReplace(wordApp, "<sem>", tbsem.Text);
                    this.FindAndReplace(wordApp, "<branch>", branch);
                    this.FindAndReplace(wordApp, "<usn>", tbusn.Text);
                }
                else
                {
                    MessageBox.Show("Incorrect USN or wrong query!");
                }
                rdusn.Close();
                int crow = 2;
                int ccol = 2;
                int gcol = 5;
                int gpcol = 6;
                int i = 0;
                double[] tgp = new double[5];
                MySqlCommand cmd1 = new MySqlCommand("Select * from academics,course where course.course_code=academics.course_code and usn='" + tbusn.Text + "'", con);
                MySqlDataReader rdusn1 = cmd1.ExecuteReader();
                while (rdusn1.Read())
                {
                    double[] test = new double[3];
                    test[0] = Convert.ToInt32((rdusn1["test1"].ToString()));
                    test[1] = Convert.ToInt32((rdusn1["test2"].ToString()));
                    test[2] = Convert.ToInt32((rdusn1["test3"].ToString()));
                    Array.Sort(test);

                    double cie = test[2] + test[1];
                    double semend = Convert.ToInt32((rdusn1["sem_end"].ToString()));
                    double score = cie + semend / 2;
                    String grade;
                    int gp;
                    if (cie < 25)
                    {
                        grade = "F";
                        gp = 0;
                    }
                    else
                    {
                        if (score <= 100 && score >= 90)
                        {
                            grade = "S";
                            gp = 10;
                        }
                        else if (score < 90 && score >= 75)
                        {
                            grade = "A";
                            gp = 9;
                        }
                        else if (score < 75 && score >= 60)
                        {
                            grade = "B";
                            gp = 8;
                        }
                        else if (score < 60 && score >= 50)
                        {
                            grade = "C";
                            gp = 7;
                        }
                        else if (score < 50 && score >= 40)
                        {
                            grade = "D";
                            gp = 6;
                        }
                        else
                        {
                            grade = "F";
                            gp = 0;
                        }
                    }

                    tgp[i] = gp;
                    i++;
                    String course = (rdusn1["course_code"].ToString());
                    String coursenm = (rdusn1["course_name"].ToString());
                    gc.Cell(crow, ccol).Range.Text = course;
                    gc.Cell(crow, ccol+1).Range.Text = coursenm;
                    gc.Cell(crow, gcol).Range.Text = grade;
                    gc.Cell(crow, gpcol).Range.Text = gp.ToString();

                    crow++;
                }

                double sgpa = (tgp.Sum())*4/20;
                this.FindAndReplace(wordApp, "<sgpa>", sgpa.ToString());

                con.Close();
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
            saveasgc.ShowDialog();
        }

        private void saveasgc_FileOk(object sender, CancelEventArgs e)
        {
            CreateWordDocument(@"G:\vstudio\dbms1\dbms1\marks card2.docx", saveasgc.FileName);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
