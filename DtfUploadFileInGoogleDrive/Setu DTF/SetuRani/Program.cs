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

using DurableTask;
using Google.Apis.Drive.v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daenet.Integration
{
    class Program
    {
        public static DriveService service;
        static void Main(string[] args)
        {
            stupid();
        }

        static void stupid() {
            string connectionString = "Endpoint=sb://currencyservice.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=x2xL3iLu0CnQQn//yco9DZ/fyJCnYj2lueSCv0vVf9U=";

            TaskHubClient taskHubClient = new TaskHubClient("avikhub", connectionString);
            TaskHubWorker taskHubWorker = new TaskHubWorker("avikhub", connectionString);
            taskHubWorker.CreateHub();

            OrchestrationInstance instance = taskHubClient.CreateOrchestrationInstance(typeof(Orchestration), "");

            taskHubWorker.AddTaskOrchestrations(typeof(Orchestration));
            taskHubWorker.AddTaskActivities(typeof(GoogleDriveAuthenticationTask),typeof(GoogleUploadTask));
            taskHubWorker.Start();
            Console.ReadLine();
            taskHubWorker.Stop(true);
        }
    }
}
