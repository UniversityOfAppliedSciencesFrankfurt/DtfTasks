//=======================================================================================
// Copyright © daenet GmbH Frankfurt am Main, University of Applied Sciences Frankfurt am Main
//
// LICENSED UNDER THE APACHE LICENSE, VERSION 2.0 (THE "LICENSE"); YOU MAY NOT USE THESE
// FILES EXCEPT IN COMPLIANCE WITH THE LICENSE. YOU MAY OBTAIN A COPY OF THE LICENSE AT
// http://www.apache.org/licenses/LICENSE-2.0
// UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING, SOFTWARE DISTRIBUTED UNDER THE
// LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED. SEE THE LICENSE FOR THE SPECIFIC LANGUAGE GOVERNING
// PERMISSIONS AND LIMITATIONS UNDER THE LICENSE.
//=======================================================================================

using System;
using DurableTask;

namespace Daenet.Integration
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
