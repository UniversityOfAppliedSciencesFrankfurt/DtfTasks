using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendsMail
{
    public partial class UserCredential : Form
    {
        public UserCredential(string body)
        {
            
            InitializeComponent();
            this.body.Text = body;
            
        }

        public string smtpAddress { get; set; }
        public string eMailFrom { get; set; }
        public string pass { get; set; }
        public string MailTo { get; set; }
        public string eSubject { get; set; }
        public string eBody { get; set; }

        /// <summary>
        /// This will collect all information from user, for example 
        /// from which email address will be sent message and password, To which email address will be sent, 
        /// message subject, message body etc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> Event Argument </param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.eMailFrom = eMail.Text;
            this.pass = passWord.Text;
            this.MailTo = eMailTo.Text;
           this.smtpAddress= smtpAdd(eMail.Text);
           this.eBody = body.Text;
           this.eSubject = subject.Text;
           this.Hide();
        }

        /// <summary>
        /// Collect smtp address from sender email address
        /// </summary>
        /// <param name="eMailFrom"></param>
        /// <returns></returns>
        private string smtpAdd(string eMailFrom)
        {
            var smtpClient = string.Empty;
            var subString = eMailFrom.Split('@','.');
            foreach (var smtp in subString)
            {
                switch(smtp.ToLower())
                {
                    case "gmail" :
                        smtpClient = "smtp.gmail.com";
                        break;
                    case "yahoo" :
                        smtpClient = " 	smtp.mail.yahoo.com";
                        break;

                    case "outlook":
                    case "hotmail":
                         	smtpClient = "smtp.live.com";
                            break;
                }
            }
            return smtpClient;

        }

        
    }
}
