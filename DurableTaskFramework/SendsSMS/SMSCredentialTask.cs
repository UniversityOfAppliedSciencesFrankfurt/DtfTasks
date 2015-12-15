using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;

namespace SendsSMS
{
   public class SMSCredentialTask : TaskActivity<string,Credentials>
    {
        /// <summary>
        /// Set all Public properties of Credentials class
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input">Contains message from TaskOrchestration</param>
        /// <returns>Credentials Object</returns>
        protected override Credentials Execute(TaskContext context, string input)
        {
            UserCredential uCredential = new UserCredential(input);
            uCredential.ShowDialog();
            Credentials credentials = new Credentials()
            {
                UserName = uCredential.eMailFrom,
                PassWord = uCredential.pass,
                SMSTo = uCredential.PhnNumber,
                 MBody = uCredential.eBody,
            };
            return credentials;
        }
    }
}
