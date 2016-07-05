using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Drive.v2;
using Daimto.Drive.api;

namespace SetuRani
{
    class GoogleDriveAuthenticationTask : TaskActivity<string, string>
    {
        
        protected override string Execute(TaskContext context, string input)
        {
            Console.WriteLine("Authentication Task");
            // Connect with Oauth2 Ask user for permission
            String CLIENT_ID = "629658075118-b9qga45jk2j63tj4njoa73id9i2riq22.apps.googleusercontent.com";
            String CLIENT_SECRET = "xDx0yev1lmWV_fPYVOYG1SJm";
            Program.service = Authentication.AuthenticateOauth(CLIENT_ID, CLIENT_SECRET, Environment.UserName);
            //Console.WriteLine(Program.service.HttpClientInitializer);

            // connect with a Service Account
            //string ServiceAccountEmail = "1046123799103-6v9cj8jbub068jgmss54m9gkuk4q2qu8@developer.gserviceaccount.com";
            //string serviceAccountkeyFile = @"C:\GoogleDevelop\Diamto Test Everything Project-78049f608668.p12";
            //DriveService service = Authentication.AuthenticateServiceAccount(ServiceAccountEmail, serviceAccountkeyFile);

            if (Program.service == null)
            {
                Console.WriteLine("Authentication error");
                Console.ReadLine();
            }
            return " ";
        }

        
    }
}
