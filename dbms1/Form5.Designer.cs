namespace dbms1
{
    partial class certif
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.tbusn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbname = new System.Windows.Forms.TextBox();
            this.tbsem = new System.Windows.Forms.TextBox();
            this.tbbranch = new System.Windows.Forms.TextBox();
            this.tbevent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.saveas1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(310, 373);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbusn
            // 
            this.tbusn.Location = new System.Drawing.Point(554, 52);
            this.tbusn.Name = "tbusn";
            this.tbusn.Size = new System.Drawing.Size(100, 20);
            this.tbusn.TabIndex = 1;
            this.tbusn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbusn_KeyPress);
            this.tbusn.Leave += new System.EventHandler(this.tbusn_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "usn";
            // 
            // tbname
            // 
            this.tbname.Location = new System.Drawing.Point(554, 101);
            this.tbname.Name = "tbname";
            this.tbname.ReadOnly = true;
            this.tbname.Size = new System.Drawing.Size(100, 20);
            this.tbname.TabIndex = 3;
            // 
            // tbsem
            // 
            this.tbsem.Location = new System.Drawing.Point(554, 149);
            this.tbsem.Name = "tbsem";
            this.tbsem.ReadOnly = true;
            this.tbsem.Size = new System.Drawing.Size(100, 20);
            this.tbsem.TabIndex = 4;
            // 
            // tbbranch
            // 
            this.tbbranch.Location = new System.Drawing.Point(554, 196);
            this.tbbranch.Name = "tbbranch";
            this.tbbranch.ReadOnly = true;
            this.tbbranch.Size = new System.Drawing.Size(100, 20);
            this.tbbranch.TabIndex = 5;
            // 
            // tbevent
            // 
            this.tbevent.Location = new System.Drawing.Point(554, 245);
            this.tbevent.Name = "tbevent";
            this.tbevent.Size = new System.Drawing.Size(100, 20);
            this.tbevent.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "conducted on";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "semester";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "branch";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "event";
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(511, 293);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(200, 20);
            this.date.TabIndex = 13;
            this.date.Value = new System.DateTime(2019, 11, 10, 7, 8, 42, 0);
            // 
            // saveas1
            // 
            this.saveas1.Filter = "Docx files (*.docx)|*.doc|All files (*.*)|*.*";
            this.saveas1.InitialDirectory = "C:\\Users\\ACER\\Desktop";
            this.saveas1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // certif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbevent);
            this.Controls.Add(this.tbbranch);
            this.Controls.Add(this.tbsem);
            this.Controls.Add(this.tbname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbusn);
            this.Controls.Add(this.button1);
            this.Name = "certif";
            this.Text = "Certificate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbusn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbname;
        private System.Windows.Forms.TextBox tbsem;
        private System.Windows.Forms.TextBox tbbranch;
        private System.Windows.Forms.TextBox tbevent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.SaveFileDialog saveas1;
    }
}