using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using Websms;

namespace SendsSMS
{
   public class SendSMSTask : TaskActivity<Credentials,string>
    {
        /// <summary>
        /// This TaskActivity send the message to given mobile number
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input">Contains message from TaskOrchestration</param>
        /// <returns></returns>
        protected override string Execute(TaskContext context, Credentials input)
        {
            int User_Phone_No = int.Parse(input.SMSTo);
            string Message_Body = input.MBody;
            string API_User_Name = input.UserName;
            string API_Password = input.PassWord;
            string API_URL = "https://api.websms.com/json";

            SmsClient client = new SmsClient(API_User_Name, API_Password, API_URL);

            // Create new message with one recipient.
            TextMessage textMessage = new TextMessage(User_Phone_No, Message_Body);

            try
            {
                // Send the message.
                MessageResponse response = client.Send(textMessage, 1, false);                
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                //MessageBox.Show("");
            }
            return null;
        }
    }
}
