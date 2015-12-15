using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace SendsMail
{
    /// <summary>
    /// This TaskActivity will create smtp client and send the mail to specific email address
    /// </summary>
   public class SendMailTask : TaskActivity<Credentials,string>
    {
        protected override string Execute(TaskContext context, Credentials input)
        {

            string smtpAddress = input.smtpAddress;
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = input.eMailFrom;
            string password = input.passWord;
            string emailTo = input.eMailTo;
            string subject = input.eSubject;
            string body = input.mBody;
            try
            {
                ///Represents an e-mail message that can be sent  
                ///            
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    // Here is created smtp client with network credentials

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                    MessageBox.Show("Message successfully send !!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return null;
        }
    }
}
