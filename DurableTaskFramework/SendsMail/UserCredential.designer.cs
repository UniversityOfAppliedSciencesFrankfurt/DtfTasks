namespace SendsMail
{
    partial class UserCredential
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eMail = new System.Windows.Forms.TextBox();
            this.passWord = new System.Windows.Forms.TextBox();
            this.eMailTo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.body = new System.Windows.Forms.TextBox();
            this.t = new System.Windows.Forms.Label();
            this.subject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-Mail : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mail To : ";
            // 
            // eMail
            // 
            this.eMail.Location = new System.Drawing.Point(91, 36);
            this.eMail.Name = "eMail";
            this.eMail.Size = new System.Drawing.Size(360, 20);
            this.eMail.TabIndex = 3;
            // 
            // passWord
            // 
            this.passWord.Location = new System.Drawing.Point(91, 67);
            this.passWord.Name = "passWord";
            this.passWord.Size = new System.Drawing.Size(360, 20);
            this.passWord.TabIndex = 4;
            this.passWord.UseSystemPasswordChar = true;
            // 
            // eMailTo
            // 
            this.eMailTo.Location = new System.Drawing.Point(91, 101);
            this.eMailTo.Name = "eMailTo";
            this.eMailTo.Size = new System.Drawing.Size(360, 20);
            this.eMailTo.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 441);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Message Body";
            // 
            // body
            // 
            this.body.Location = new System.Drawing.Point(91, 211);
            this.body.Multiline = true;
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(360, 209);
            this.body.TabIndex = 8;
            // 
            // t
            // 
            this.t.AutoSize = true;
            this.t.Location = new System.Drawing.Point(16, 134);
            this.t.Name = "t";
            this.t.Size = new System.Drawing.Size(40, 13);
            this.t.TabIndex = 9;
            this.t.Text = "Subjec";
            // 
            // subject
            // 
            this.subject.Location = new System.Drawing.Point(91, 134);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(360, 20);
            this.subject.TabIndex = 10;
            this.subject.Text = "Yahoo Weather Forecasts!";
            // 
            // UserCredential
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 499);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.t);
            this.Controls.Add(this.body);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.eMailTo);
            this.Controls.Add(this.passWord);
            this.Controls.Add(this.eMail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UserCredential";
            this.Text = "UserCredential";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox eMail;
        private System.Windows.Forms.TextBox passWord;
        private System.Windows.Forms.TextBox eMailTo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox body;
        private System.Windows.Forms.Label t;
        private System.Windows.Forms.TextBox subject;
    }
}