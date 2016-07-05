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
using DropboxRestAPI;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace Daenet.Integration
{

    
    class AuthenticationTask : TaskActivity<string,string>
	{
		
		static string app_key = "xo1gmrp0rbe5dqa";
		static string app_secret = "jbqhsqgyi1nsyst";
		static string CallbackUrl = "http://localhost";
        //static string AccesToken = "pnGoEUn2_p4AAAAAAAAcyxQTQiRTusIJV0BMi_wKhjujxW8Cp316DTkW6KpGgeLf";

        protected override string Execute (TaskContext context, string input)
		{
            var options = new Options
            {
                ClientId = app_key,
                ClientSecret = app_secret,
                RedirectUri = CallbackUrl
            };
            var client = new Client(options);

            var authRequestUrl =  client.Core.OAuth2.Authorize("code");
            var accessToken = String.Empty;
            var t = new Thread(delegate ()
            {
                
                BrowserManager register = new BrowserManager(authRequestUrl.ToString());
                var token = register.Access_Token;
                Console.WriteLine(token);
                accessToken = client.Core.OAuth2.TokenAsync(token).Result.access_token;
                //Console.WriteLine(accessToken);

            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();


            return accessToken;
            //Console.WriteLine("I am in task");
	
			
		}

		

	}
}

