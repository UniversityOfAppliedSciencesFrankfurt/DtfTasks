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
using RestSharp.Authenticators.OAuth;
using System.Threading;
using DaenetIntegration;

namespace Daenet.Integration
{

   

    class MainClass
	{
		public static string baseUrl = "https://api.xing.com";

		public static void Main (string[] args)
		{
			startDurableTask ();
		}

		static void startDurableTask(){

			string connectionString = "Endpoint=sb://currencyservice.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=x2xL3iLu0CnQQn//yco9DZ/fyJCnYj2lueSCv0vVf9U=";

			TaskHubClient taskHubClient = new TaskHubClient("avikhub", connectionString);
			TaskHubWorker taskHubWorker = new TaskHubWorker("avikhub", connectionString);
			taskHubWorker.CreateHub();

            OrchestrationInstance instance = taskHubClient.CreateOrchestrationInstance(typeof(TaskOrchestra), "");

			taskHubWorker.AddTaskOrchestrations(typeof(TaskOrchestra));
			taskHubWorker.AddTaskActivities(typeof(AuthenticationTask),typeof(UploadTask));
			taskHubWorker.Start();
            Console.ReadLine();
            taskHubWorker.Stop(true);
		}
	}
}
