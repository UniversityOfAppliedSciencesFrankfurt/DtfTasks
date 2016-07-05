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
using System;

namespace Daenet.Integration
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var fileToUpload = @"C:\Program Files\Common Files\Microsoft Shared\ink\en-US\delete.avi";
            DurableTask(fileToUpload);
        }

        public static void DurableTask(string videoUrl)
        {
            string connectionString = "Endpoint=sb://currencyservice.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=x2xL3iLu0CnQQn//yco9DZ/fyJCnYj2lueSCv0vVf9U=";
            TaskHubClient taskHubClient = new TaskHubClient("myHub", connectionString);
            TaskHubWorker taskHubWorker = new TaskHubWorker("myHub", connectionString);
            taskHubWorker.CreateHub();
            OrchestrationInstance instance = taskHubClient.CreateOrchestrationInstance(typeof(TaskOrchestration), videoUrl);
            taskHubWorker.AddTaskOrchestrations(typeof(TaskOrchestration));
            taskHubWorker.AddTaskActivities(typeof(GetAccessTokenTask), typeof(UploadVideoTask));
            taskHubWorker.Start();
            Console.ReadLine();
            taskHubWorker.Stop(true);
        }
    }
}