using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
using System.Threading;
using System.Configuration;

namespace PostFacebookGraphAPI
{
    /// <summary>
    /// Collect the access token by using facebook graph api
    /// </summary>
    public class AccessTokenTask : TaskActivity<string,string>
    {
        protected override string Execute(TaskContext context, string input)
        {

            string token = null;

            var t = new Thread(delegate()
            {
                string link = ConfigurationManager.AppSettings["graphFbLink"];
                RegisterBrowser register = new RegisterBrowser(link);
                token = register.Access_Token;
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            if (token == null)
                throw new ArgumentException("Token is not properly initialized!");

            return token;
        }
    }
}
