using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;

namespace SendsMail
{
    /// <summary>
    /// The CredentialTask TaskActivity will collect all of information about sender and receiver, for example
    /// sender email address and password, receiver email address, smtp address, message subject and message body
    /// </summary>
   public class CredentialTask : TaskActivity<string,Credentials>
    {
        protected override Credentials Execute(TaskContext context, string input)
        {
            UserCredential uCredential = new UserCredential(input);
            uCredential.ShowDialog();
            Credentials credentials = new Credentials()
            {
                eMailFrom = uCredential.eMailFrom,
                passWord = uCredential.pass,
                eMailTo = uCredential.MailTo,
                smtpAddress = uCredential.smtpAddress,
                 mBody = uCredential.eBody,
                 eSubject = uCredential.eSubject
            };
            return credentials;
        }
    }
}
